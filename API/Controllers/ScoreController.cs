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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ScoreController : APIController
    {
        private readonly DataContext _context;

        public ScoreController(DataContext context)
        {
            this._context = context;
        }
        [HttpGet("myscore/{id}")]
        public async Task<ActionResult<IEnumerable<Score>>> GetScore(int id) {
            return await _context.Scores
            .Include(x => x.Student)
            .Include(x => x.group)
            .Where(x => x.StudentId == id).ToListAsync();
        }
        //Select Id, StudentId,Grades, ClassesclId, Class_name, Name from scores as s classes as c, courses as cs where StudentId = 1 and s.ClassesclId = c.clId and c.CourseId = cs.cId;
    }
}