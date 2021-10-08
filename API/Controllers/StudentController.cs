using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class StudentController : APIController
    {
        private readonly DataContext _context;

        public StudentController(DataContext context)
        {
            this._context = context;
        }
        AppUser user = new AppUser();

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("create")]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            if (await StudentExists(student.Id)) return BadRequest("The Identity of Student is exist");

            student.Birthday = DateTime.Now;
            student.Start_date = DateTime.Now;
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [Authorize(Policy = "RequireAdminRole")]
        private async Task<bool> StudentExists(int id)
        {
            return await _context.Students.AnyAsync(x => x.Id == id);
        }
    }
}
