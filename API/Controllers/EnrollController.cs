using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollController : ControllerBase
    {
        
        private readonly DataContext _context;

        public EnrollController(DataContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enrolled>>> GetEnrolled() {
            return await _context.Enrolleds.ToListAsync();
        }
        [HttpPost("register")]
        public async Task<ActionResult<Enrolled>> SetEnroll(Enrolled enrolled) {
            if(await ClassExists(enrolled.ClassesId)) return BadRequest("The name of the course is exists!!");
            _context.Enrolleds.Add(enrolled);
            await _context.SaveChangesAsync();
            return Ok();
        }
        private async Task<bool> ClassExists(int id)
        {
            return await _context.Enrolleds.AnyAsync(x => x.ClassesId == id);
        }
    }
}