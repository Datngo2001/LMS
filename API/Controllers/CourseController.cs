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

namespace API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : APIController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserManager<AppUser> _userManager { get; }
        private readonly ICourseRepository _courseRepo;
        public CourseController(DataContext context, ICourseRepository courseRepository, UserManager<AppUser> userManager, IMapper mapper)
        {
            this._userManager = userManager;
            this._mapper = mapper;
            this._context = context;
            this._courseRepo = courseRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourse()
        {
            var rs = await _context.Courses.ToListAsync();
            return rs;
        }
        [Authorize(Policy = "All")]
        [HttpGet("mycourses")]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetEnrolledCourse()
        {
            var rs = await _courseRepo.GetEnrolledCourse(User.GetUserId());
            return rs.ToArray();
        }
        [Authorize(Policy = "All")]
        [HttpGet("course")]
        public async Task<ActionResult<CourseDto>> GetCourseOfGroup(int gId)
        {
            var uId = User.GetUserId();
            bool isEnrolled = await _courseRepo.isStudentEnrolled(uId, gId);
            if (isEnrolled)
            {
                return await _courseRepo.LoadCourseContent(gId);
            }
            else
            {
                return BadRequest("You have not taken this course yet");
            }
        }
    }
}