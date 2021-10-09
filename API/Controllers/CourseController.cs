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

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly DataContext _context;

        public CourseController(DataContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourse() {
            return await _context.Courses.ToListAsync();
        }
        [HttpPost("Create")]
        public async Task<ActionResult<Course>> CreateClass(Course course)
        {
            if (await CourseExists(course.Name)) return BadRequest("The name of the course is exists!!");
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("mycourse/{id}")]
        public async Task<ActionResult<IEnumerable<Classes>>> GetCourses(int id) {
            //"SELECT * FROM lms.classes as c, lms.enrolleds as e where StudentId = {0} and c.clId = e.ClassesId"
            return await _context.Classes.Include(x => x.Course).Where(s => s.CourseId == id).ToListAsync();
        }
        private async Task<bool> CourseExists(string name)
        {
            return await _context.Courses.AnyAsync(x => x.Name == name);
        }

    }
}