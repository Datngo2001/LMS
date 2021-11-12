using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.DTOs;
using API.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using API.Extensions;
using AutoMapper;

namespace API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class CourseController : APIController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CourseController(DataContext context, UserManager<AppUser> userManager, IMapper mapper)
        {
            this._mapper = mapper;
            this._context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourse()
        {
            var rs = await _context.Courses.ToListAsync();
            return rs;
        }
    }
}