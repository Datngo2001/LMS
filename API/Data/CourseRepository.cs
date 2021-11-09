using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.CourseComponent;
using API.DTOs.DashBoardComponent;
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
                          join g in _context.Groups on c.cId equals g.CourseId
                          where g.gId == gId
                          orderby g.gId
                          select new CourseDto()
                          {
                              cId = c.cId,
                              Name = c.Name,
                              Description = c.Description,
                              Credits = c.Credits,
                              Group = new GroupDto()
                              {
                                  GId = g.gId,
                                  GroupName = g.Group_name,
                                  StartDate = g.Start_date,
                                  EndDate = g.End_date,
                                  Lecturer = g.TeacherId.ToString(),
                                  EnrollSlot = g.Enroll_slot,
                                  Term = g.Term,
                                  TotalTime = g.TotalTime,
                                  TotalSlot = g.Total_slot,
                                  Lessons = (from l in g.Lessons
                                             where l.groupId == g.gId
                                             orderby l.Order
                                             select new LessonDto()
                                             {
                                                 lId = l.lId,
                                                 Order = l.Order,
                                                 Name = l.Name,
                                                 Contents = (from ct in l.Contents
                                                             where ct.LessonlId == l.lId
                                                             select new ContentDto()
                                                             {
                                                                 cId = ct.cId,
                                                                 Type = ct.Type,
                                                                 Title = ct.Title,
                                                                 Description = ct.Description
                                                             }).ToList()
                                             }).ToList()
                              }
                          }).AsSingleQuery().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CourseCardDto>> GetEnrolledCourse(int userId)
        {
            return await (from c in _context.Courses
                          join g in _context.Groups on c.cId equals g.gId
                          join e in _context.Enrolleds on g.gId equals e.eId
                          join s in _context.Students on e.StudentId equals s.Id
                          where s.UserId == userId
                          select new CourseCardDto()
                          {
                              cId = c.cId,
                              Name = c.Name,
                              Group_name = g.Group_name,
                              gId = g.gId
                          }).ToArrayAsync();
        }

        public async Task<bool> isEnrolled(int uId, int gId)
        {
            var rs = await (from g in _context.Groups
                            join e in _context.Enrolleds on g.gId equals e.eId
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
    }
}