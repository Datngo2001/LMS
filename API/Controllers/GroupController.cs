using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AutoMapper;
using API.DTOs;

namespace API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GroupController : APIController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GroupController(DataContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<GroupDto>>> GetGroups()
        {
            var group = await _context.Groups.Include(c => c.Course).ToListAsync();
            var classes = _mapper.Map<IEnumerable<GroupDto>>(group);
            return Ok(classes);
        }
        [HttpGet("list/{id}")]
        public async Task<ActionResult<IEnumerable<GroupDto>>> GetGroups(int id)
        {
            var group = await _context.Groups.Include(c => c.Course).Where(x => x.CourseId == id).ToListAsync();
            var classes = _mapper.Map<IEnumerable<GroupDto>>(group);
            return Ok(classes);
        }
        [HttpPost("create")]
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