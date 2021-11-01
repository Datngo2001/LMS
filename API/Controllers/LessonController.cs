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
    public class LessonController : APIController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public LessonController(DataContext context,  IMapper mapper)
        {
        this._context = context;
        this._mapper = mapper;
        }
        [HttpPost("create")]
        public async Task<ActionResult<Content>> CreateContent(Content content) 
        {
            if(await ContentExists(content.cId)) return BadRequest("The id of the content is exist!");
            _context.Contents.Add(content);
            await _context.SaveChangesAsync();
            return Ok();

        }
        [HttpGet("content/{id}")]
        public async Task<ActionResult<IEnumerable<Content>>> GetContent(int id)
        {
            return await _context.Contents.Where(x => x.Lesson.groupId == id).ToListAsync();

        }
        private async Task<bool> ContentExists(int id)
        {
            return await _context.Contents.AnyAsync(x => x.cId == id);
        }
    }
}