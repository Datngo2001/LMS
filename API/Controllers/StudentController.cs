using API.Data;
using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class StudentController : APIController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public StudentController(DataContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        AppUser user = new AppUser();

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("create")]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            if (await StudentExists(student.Id)) return BadRequest("The Identity of Student is exist");
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return Ok();
        }
       
        // [HttpGet("mycourse")]
        // public async Task<ActionResult<IEnumerable<Group>>> GetCourse(int cid)
        // {
        //     return await _context.Groups.FromSqlRaw("select * from groups where Id = {0}", cid).ToListAsync();
        // }
        // [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("mycourse")]
        public async Task<ActionResult<IEnumerable<EnrolledDto>>> GetCourses()
        {
            var userId = User.GetUserId();
            //"SELECT * FROM lms.classes as c, lms.enrolleds as e where StudentId = {0} and c.clId = e.ClassesId"
            var group = await _context.Enrolleds.Include(x => x.group).Include(x => x.group.Course).Where(x => x.StudentId == userId).ToListAsync();
            var mycourse = _mapper.Map<IEnumerable<EnrolledDto>>(group);
            return Ok(mycourse);
        }

        [Authorize(Policy = "RequireAdminRole")]
        private async Task<bool> StudentExists(int id)
        {
            return await _context.Students.AnyAsync(x => x.Id == id);
        }
    }
}
