using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.DTOs;
using API.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using API.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class CourseController : APIController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;
        private readonly UserManager<AppUser> _userManager;

        public CourseController(DataContext context, UserManager<AppUser> userManager, IMapper mapper, IPhotoService photoService)
        {
            this._mapper = mapper;
            this._photoService = photoService;
            this._context = context;
            this._userManager = userManager;
        }

        [HttpGet("cards")]
        public async Task<ActionResult<IEnumerable<CourseCardDto>>> GetCourseCard()
        {
            int userId = User.GetUserId();

            var courseCards = await _context.Enrolleds
                .Include(e => e.course)
                    .ThenInclude(c => c.Teacher)
                .Include(e => e.course)
                    .ThenInclude(c => c.Photo)
                .Where(e => e.appUserId == userId)
                .Select(e => _mapper.Map<CourseCardDto>(e.course))
                .ToArrayAsync();

            return courseCards;
        }

        [AllowAnonymous]
        [HttpGet("enrollecards")]
        public async Task<ActionResult<IEnumerable<CourseCardDto>>> GetEnrolleCard()
        {
            var courseCards = await _context.Courses
                .Include(c => c.Photo)
                .Include(c => c.Teacher)
                .Select(c => _mapper.Map<CourseCardDto>(c))
                .ToArrayAsync();

            return courseCards;
        }


        [Authorize(Policy = "TeacherAdminRole")]
        [HttpPost("createcourse")]
        public async Task<ActionResult> CreateCourse(CreateCourseDto createCourseDto)
        {
            int userId = User.GetUserId();

            var user = await _userManager.FindByIdAsync(userId.ToString());
            Course course = _mapper.Map<Course>(createCourseDto);
            course.Teacher = user;

            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();

            await _context.Enrolleds.AddAsync(new Enrolled()
            {
                appUser = user,
                course = course
            });

            await _context.SaveChangesAsync();

            return Ok("Course " + course.Name + " created by " + user.UserName);
        }

        [Authorize(Policy = "TeacherAdminRole")]
        [HttpPost("updatecourse/{cid}")]
        public async Task<ActionResult> UpdateCourse(int cid, UpdateCourseDto updateCourseDto)
        {
            int userId = User.GetUserId();

            if (!(await _context.Courses.AnyAsync(c => c.TeacherId == userId && c.Id == cid)))
            {
                return BadRequest("Invalid user");
            }

            Course course = await _context.Courses.FindAsync(cid);
            _mapper.Map(updateCourseDto, course);

            await _context.SaveChangesAsync();

            return Ok("Course edited.");
        }

        [Authorize(Policy = "TeacherAdminRole")]
        [HttpPost("updateimage/{cid}")]
        public async Task<ActionResult<PhotoDto>> UpdateImage(int cid, IFormFile file)
        {
            int userId = User.GetUserId();

            if (!(await _context.Courses.AnyAsync(c => c.TeacherId == userId && c.Id == cid)))
            {
                return BadRequest("Invalid user");
            }

            Course course = await _context.Courses.Include(c => c.Photo).FirstOrDefaultAsync(c => c.Id == cid);

            if (course.Photo != null)
            {
                await _photoService.DeletePhotoAsync(course.Photo.PublicId);
            }

            var result = await _photoService.AddPhotoAsync(file);
            if (result.Error != null) return BadRequest(result.Error.Message);
            var photo = new Photo
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

            course.Photo = photo;
            await _context.SaveChangesAsync();

            return _mapper.Map<PhotoDto>(photo);
        }

        [Authorize(Policy = "TeacherAdminRole")]
        [HttpPost("deletecourse/{cid}")]
        public async Task<ActionResult> DeleteCourse(int cid)
        {
            int userId = User.GetUserId();

            if (!(await _context.Courses.AnyAsync(c => c.TeacherId == userId && c.Id == cid)))
            {
                return BadRequest("Invalid user");
            }

            Course course = await _context.Courses.FindAsync(cid);

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return Ok("Course Deleted");
        }
    }
}