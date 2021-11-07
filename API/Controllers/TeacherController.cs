using API.Data;
using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace API.Controllers   

{

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TeacherController : APIController
    {
        private readonly DataContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public TeacherController(DataContext context, UserManager<AppUser> userManager, IMapper mapper)
        {
            this._context = context;
            this._userManager = userManager;
            this._mapper = mapper;
        }

        [HttpGet("myclass")]
        public async Task<ActionResult<IEnumerable<GroupDto>>> GetClass()
        {
            var userId = User.GetUserId();
            var group =  await _context.Groups.Include(x => x.Course)
            .Where(x => x.TeacherId == 1).ToListAsync();
            var classes = _mapper.Map<IEnumerable<GroupDto>>(group);
            return Ok(classes);
        }
        [HttpGet("class/{id}")]
        public async Task<ActionResult<IEnumerable<GroupDto>>> GetClassDetail(int id)
        {
            var group =  await _context.Groups.Include(x => x.Course)
            .Where(x => x.gId == id).ToListAsync();
            var classes = _mapper.Map<IEnumerable<GroupDto>>(group);
            return Ok(classes);
        }
        
    }   
}