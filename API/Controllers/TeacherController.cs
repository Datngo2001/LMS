using API.Data;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interfaces;
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
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ITeacherRepository _teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository, UserManager<AppUser> userManager, IMapper mapper)
        {
            this._teacherRepository = teacherRepository;
            this._userManager = userManager;
            this._mapper = mapper;
        }

        [Authorize(Policy = "TeacherAdminRole")]
        [HttpGet("{{courseId}}/creategroup")]
        public async Task<ActionResult> CreateGroup(int courseId, GroupDto groupDto)
        {
            var userId = User.GetUserId();

            return Ok();
        }

        [Authorize(Policy = "TeacherAdminRole")]
        [HttpGet("teachingGroups")]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetTeachingGroups()
        {
            var userId = User.GetUserId();

            return Ok();
        }
        [Authorize(Policy = "TeacherAdminRole")]
        [HttpGet("group/{id}")]
        public async Task<ActionResult<IEnumerable<GroupDto>>> GetGroupContent(int id)
        {
            var userId = User.GetUserId();

            return Ok();
        }

        [Authorize(Policy = "TeacherAdminRole")]
        [HttpPost("updategroup/{id}")]
        public async Task<ActionResult> UpdateGroupContent(int id, GroupDto groupDto)
        {
            var userId = User.GetUserId();

            return Ok();
        }


        [Authorize(Policy = "TeacherAdminRole")]
        [HttpPost("deletegroup/{id}")]
        public async Task<ActionResult> DeleteGroup(int id)
        {
            var userId = User.GetUserId();

            return Ok();
        }
    }
}