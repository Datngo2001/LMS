using API.Data;
using API.Entities;
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
    public class TeacherController: APIController
    {
        private readonly DataContext _context;

        public TeacherController(DataContext context)
        {
            this._context = context;
        }
        [HttpGet("myclass/{id}")]
        public async Task<ActionResult<IEnumerable<Classes>>> GetClass(int id) {
            return await _context.Classes.Include(x => x.Course).Where(x => x.TeacherId == id).ToListAsync();
        }
    }
}