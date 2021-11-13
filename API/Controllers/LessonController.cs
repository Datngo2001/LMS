using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LessonController : APIController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IUploadService _uploadService;
        private readonly UserManager<AppUser> _userManager;

        public LessonController(DataContext context, UserManager<AppUser> userManager, IMapper mapper, IUploadService photoService)
        {
            this._mapper = mapper;
            this._uploadService = photoService;
            this._context = context;
            this._userManager = userManager;
        }

        [Authorize(Policy = "TeacherAdminRole")]
        [HttpPost("createlesson")]
        public async Task<ActionResult> CreateLesson(CreateLessonDto createLessonDto)
        {
            int userId = User.GetUserId();

            var isOwner = await _context.Courses.AnyAsync(c => c.Id == createLessonDto.courseId && c.TeacherId == userId);
            if (!isOwner)
            {
                return BadRequest("You are not the owner of this course");
            }

            var lesson = _mapper.Map<Lesson>(createLessonDto);
            _context.Lessons.Add(lesson);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [Authorize(Policy = "TeacherAdminRole")]
        [HttpPost("updatelesson")]
        public async Task<ActionResult> UpdateLesson(UpdateLessonDto updateLessonDto)
        {
            int userId = User.GetUserId();

            var isOwner = await _context.Courses.AnyAsync(c => c.Id == updateLessonDto.courseId && c.TeacherId == userId);
            if (!isOwner)
            {
                return BadRequest("You are not the owner of this course");
            }

            var isExist = await _context.Lessons.AnyAsync(l => l.Id == updateLessonDto.Id && l.courseId == updateLessonDto.courseId);
            if (!isExist)
            {
                return BadRequest("This lesson not exist in this course");
            }

            Lesson lesson = await _context.Lessons.FindAsync(updateLessonDto.Id);
            _mapper.Map(updateLessonDto, lesson);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [Authorize(Policy = "TeacherAdminRole")]
        [HttpPost("updatevideo/{cid}/{lid}")]
        public async Task<ActionResult<VideoDto>> UpdateVideo(int cid, int lid, IFormFile file)
        {
            int userId = User.GetUserId();

            var isOwner = await _context.Courses.AnyAsync(c => c.Id == cid && c.TeacherId == userId);
            if (!isOwner)
            {
                return BadRequest("You are not the owner of this course");
            }

            var isExist = await _context.Lessons.AnyAsync(l => l.Id == lid && l.courseId == cid);
            if (!isExist)
            {
                return BadRequest("This lesson not exist in this course");
            }

            Lesson lesson = await _context.Lessons.Include(l => l.Video).FirstAsync(l => l.Id == lid);

            if (lesson.Video != null)
            {
                await _uploadService.DeleteAsync(lesson.Video.PublicId);
            }

            var result = await _uploadService.AddVideoAsync(file);
            if (result.Error != null) return BadRequest(result.Error.Message);
            var video = new Video
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

            lesson.Video = video;
            await _context.SaveChangesAsync();

            return _mapper.Map<VideoDto>(video);
        }

        [Authorize(Policy = "TeacherAdminRole")]
        [HttpGet("deletelesson/{cid}/{lid}")]
        public async Task<ActionResult> DeleteCourse(int cid, int lid)
        {
            int userId = User.GetUserId();

            var isOwner = await _context.Courses.AnyAsync(c => c.Id == cid && c.TeacherId == userId);
            if (!isOwner)
            {
                return BadRequest("You are not the owner of this course");
            }

            var isExist = await _context.Lessons.AnyAsync(l => l.Id == lid && l.courseId == cid);
            if (!isExist)
            {
                return BadRequest("This lesson not exist in this course");
            }

            Lesson lesson = await _context.Lessons.Include(l => l.Video).FirstAsync(l => l.Id == lid);

            if (lesson.Video != null)
            {
                await _uploadService.DeleteAsync(lesson.Video.PublicId);
            }

            _context.Lessons.Remove(lesson);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}