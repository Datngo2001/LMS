using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : APIController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IUploadService _uploadService;
        private readonly UserManager<AppUser> _userManager;

        public UserController(DataContext context, UserManager<AppUser> userManager, IMapper mapper, IUploadService photoService)
        {
            this._mapper = mapper;
            this._uploadService = photoService;
            this._context = context;
            this._userManager = userManager;
        }

        [HttpGet("enroll/{cId}")]
        public async Task<ActionResult> Enroll(int cId)
        {
            int userId = User.GetUserId();

            var isEnrolled = await _context.Enrolleds.AnyAsync(e => e.appUserId == userId && e.courseId == cId);
            if (isEnrolled)
            {
                return BadRequest("Your already have this course");
            }

            Course course = await _context.Courses.FindAsync(cId);
            if (course == null)
            {
                return BadRequest("This course is not exist!");
            }

            var user = await _userManager.FindByIdAsync(userId.ToString());
            Enrolled enrolled = new Enrolled()
            {
                course = course,
                appUser = user
            };

            _context.Add(enrolled);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("unenroll/{cId}")]
        public async Task<ActionResult> Unenroll(int cId)
        {
            int userId = User.GetUserId();

            var isEnrolled = await _context.Enrolleds.AnyAsync(e => e.appUserId == userId && e.courseId == cId);
            if (!isEnrolled)
            {
                return BadRequest("Your don't have this course");
            }

            var enroll = await _context.Enrolleds.FirstAsync(e => e.appUserId == userId && e.courseId == cId);

            _context.Remove(enroll);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}