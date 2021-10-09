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

namespace API.Controllers
{
    public class ClassesController : ControllerBase
    {
        private readonly DataContext _context;

        public ClassesController(DataContext context)
        {
            this._context = context;
        }
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<Classes>>> GetClass() {
            return await _context.Classes.Include(c => c.Course).ToListAsync();
        }
        [HttpPost("Create")]
        public async Task<ActionResult<Classes>> CreateClass(Classes classes) {
            if(await ClassExists(classes.Class_name)) return BadRequest("The name of the course is exists!!");
            _context.Classes.Add(classes);
            await _context.SaveChangesAsync();
            return Ok();
        }
        private async Task<bool> ClassExists(string name)
        {
            return await _context.Classes.AnyAsync(x => x.Class_name == name);
        }
    }
}