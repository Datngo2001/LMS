using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GroupController : APIController
    {
        private readonly DataContext _context;

        public GroupController(DataContext context)
        {
            this._context = context;
        }
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroups()
        {
            return await _context.Groups.Include(c => c.Course).ToListAsync();
        }
        [HttpGet("List/{id}")]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroups(int id)
        {
            return await _context.Groups.Include(c => c.Course).Where(x => x.gId == id).ToListAsync();
        }
        [HttpPost("Create")]
        public async Task<ActionResult<Group>> CreateGroup(Group group)
        {
            if (await GroupExists(group.Group_name)) return BadRequest("The name of the course is exists!!");
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();
            return Ok();
        }
        private async Task<bool> GroupExists(string name)
        {
            return await _context.Groups.AnyAsync(x => x.Group_name == name);
        }
    }
}