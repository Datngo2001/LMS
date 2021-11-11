using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using API.Data;
using API.Interfaces;
using API.DTOs.CourseComponent;
using API.DTOs;
using System.Collections.Generic;
using System;

namespace API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AdminController : APIController
    {
        public UserManager<AppUser> _userManager { get; }
        private readonly ICourseRepository _courseRepository;
        private readonly IFacultyRepository _facultyRepository;
        public AdminController(UserManager<AppUser> userManager, ICourseRepository courseRepository, IFacultyRepository facultyRepository)
        {
            this._courseRepository = courseRepository;
            this._userManager = userManager;
            this._facultyRepository = facultyRepository;
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("users-with-roles")]
        public async Task<ActionResult> GetUserWithRoles()
        {
            var users = await _userManager.Users
                .Include(r => r.UserRoles)
                .ThenInclude(r => r.Role)
                .OrderBy(u => u.UserName)
                .Select(u => new
                {
                    u.Id,
                    Username = u.UserName,
                    Roles = u.UserRoles.Select(r => r.Role.Name)
                })
                .ToListAsync();

            return Ok(users);
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("edit-roles/{username}")]
        public async Task<ActionResult> EditRoles(string username, [FromQuery] string roles)
        {
            var selectedRoles = roles.Split(",").ToArray();

            var user = await _userManager.FindByNameAsync(username);

            if (user == null) return NotFound("Could not find user");

            var userRoles = await _userManager.GetRolesAsync(user);

            var result = await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles));

            if (!result.Succeeded) return BadRequest("Failse to add to roles");

            result = await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles));

            if (!result.Succeeded) return BadRequest("Failse to remove to roles");

            return Ok(await _userManager.GetRolesAsync(user));
        }


        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("faculties")]
        public async Task<ActionResult<IEnumerable<FacultyDto>>> getAllFacultyAndMajor()
        {
            var rs = await _facultyRepository.getAllFacultyAndMajor();
            return rs.ToArray();
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("createfaculty")]
        public async Task<ActionResult<Course>> CreateFaculty(FacultyDto facultyDto)
        {
            Faculty faculty = new Faculty()
            {
                Name = facultyDto.Name
            };
            bool isConplete = await _facultyRepository.AddFaculty(faculty);
            if (isConplete)
            {
                return Ok("Created " + facultyDto.Name + " faculty.");
            }
            else
            {
                return BadRequest("This faculty is exist");
            }
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("{FacultyName}/addmajor")]
        public async Task<ActionResult<Course>> addMajor(string FacultyName, MajorDto majorDto)
        {
            Major major = new Major()
            {
                Name = majorDto.Name
            };
            bool isConplete = await _facultyRepository.AddMajorToFaculty(major);
            if (isConplete)
            {
                return Ok("Created " + major.Name + " major in " + FacultyName + " faculty.");
            }
            else
            {
                return BadRequest("This major " + major.Name + " is exist or in valid Faculty name: " + FacultyName);
            }
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("{majorID}/createcourse")]
        public async Task<ActionResult<Course>> CreateCourse(int majorID, CourseDto courseDto)
        {
            Course course = new Course()
            {
                Name = courseDto.Name,
                Description = courseDto.Description,
                Credits = courseDto.Credits,
                majorId = majorID
            };
            bool isConplete = await _courseRepository.AddCourse(course);
            if (isConplete)
            {
                return Ok("Created " + course.Name);
            }
            else
            {
                return BadRequest("This course " + course.Name + " is exist or in valid major id: " + majorID);
            }
        }
    }
}