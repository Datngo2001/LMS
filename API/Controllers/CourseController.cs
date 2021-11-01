using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.DTOs;
using API.Interfaces;
using System.Collections;
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

        public CourseController(DataContext context, UserManager<AppUser> userManager, IMapper mapper)
        {
            this._userManager = userManager;
            this._mapper = mapper;
            this._context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourse()
        {
            return await _context.Courses.ToListAsync();
        }
        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("Create")]
        public async Task<ActionResult<Course>> CreateCourse(Course course)
        {
            if (await CourseExists(course.Name)) return BadRequest("The name of the course is exists!!");
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return Ok();
        }
        private async Task<bool> CourseExists(string name)
        {
            return await _context.Courses.AnyAsync(x => x.Name == name);
        }

    }
}