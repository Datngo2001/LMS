using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DataContext _context;

        public CourseRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<CourseDto> LoadCourseContent(int gId)
        {
            return await (from c in _context.Courses
                          join g in _context.Groups on c.Id equals g.CourseId
                          where g.Id == gId
                          orderby g.Id
                          select new CourseDto()
                          {
                              Id = c.Id,
                              Name = c.Name,
                              Description = c.Description,
                              Credits = c.Credits,
                              Groups = new List<GroupDto>(){new GroupDto()
                              {
                                  Id = g.Id,
                                  GroupName = g.Group_name,
                                  StartDate = g.Start_date,
                                  EndDate = g.End_date,
                                  Lecturer = g.TeacherId.ToString(),
                                  EnrollSlot = g.Enroll_slot,
                                  Term = g.Term,
                                  TotalTime = g.TotalTime,
                                  TotalSlot = g.Total_slot,
                                  Lessons = (from l in g.Lessons
                                             where l.groupId == g.Id
                                             orderby l.Order
                                             select new LessonDto()
                                             {
                                                 Id = l.Id,
                                                 Order = l.Order,
                                                 Name = l.Name,
                                                 Contents = (from ct in l.Contents
                                                             where ct.LessonlId == l.Id
                                                             select new ContentDto()
                                                             {
                                                                 Id = ct.Id,
                                                                 Type = ct.Type,
                                                                 Title = ct.Title,
                                                                 Description = ct.Description
                                                             }).ToList()
                                             }).ToList()
                              }}
                          }).AsSingleQuery().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CourseDto>> GetEnrolledCourse(int userId)
        {
            return await (from c in _context.Courses
                          join g in _context.Groups on c.Id equals g.Id
                          join e in _context.Enrolleds on g.Id equals e.Id
                          join s in _context.Students on e.StudentId equals s.Id
                          where s.UserId == userId
                          select new CourseDto()
                          {
                              Id = c.Id,
                              Name = c.Name,
                              Groups = new List<GroupDto>(){
                                  new GroupDto(){
                                      Id = g.Id,
                                      GroupName = g.Group_name
                                  }
                              }
                          }).ToArrayAsync();
        }

        public async Task<bool> isStudentEnrolled(int uId, int gId)
        {
            var rs = await (from g in _context.Groups
                            join e in _context.Enrolleds on g.Id equals e.Id
                            join s in _context.Students on e.StudentId equals s.Id
                            where s.UserId == uId && e.groupId == gId
                            select g
                            ).ToArrayAsync();
            if (rs.Length > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> AddCourse(Course course)
        {
            Major major = await _context.Majors.Include(m => m.Courses).FirstOrDefaultAsync(m => m.Id == course.majorId);
            if (major == null)
            {
                return false;
            }
            else if (major.Courses == null)
            {
                major.Courses = new List<Course>();
            }
            else if (major.Courses.Any(c => c.Name == course.Name))
            {
                return false;
            }
            major.Courses.Add(course);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<bool> UpdateCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> isCourseExist(Course course)
        {
            return await _context.Courses.AnyAsync(c => c.Id == course.Id);
        }
    }
}