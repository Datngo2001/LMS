using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using API.DTOs;

namespace API.Data
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly DataContext _context;

        public TeacherRepository(DataContext context)
        {
            this._context = context;
        }
        public async Task<Teacher> GetTeacher(int uId)
        {
            return await _context.Teachers.FirstOrDefaultAsync(t => t.UserId == uId);
        }
        public async Task<bool> CreateGroup(Group group, int uId)
        {
            Course course = await _context.Courses.Include(c => c.Groups).FirstOrDefaultAsync(c => c.Id == group.CourseId);
            if (course == null)
            {
                return false;
            }
            else if (course.Groups == null)
            {
                course.Groups = new List<Group>();
            }
            else if (course.Groups.Any(g => g.Group_name == group.Group_name))
            {
                return false;
            }
            group.Teacher = await GetTeacher(uId);
            course.Groups.Add(group);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteGroup(int gId, int uId)
        {
            var group = await _context.Groups.Include(g => g.Teacher).FirstAsync(g => g.Teacher.UserId == uId && g.Id == gId);
            if (group == null)
            {
                return false;
            }
            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<GroupDto>> GetGroupContent(int gId, int uId)
        {
            var teacher = await GetTeacher(uId);
            return await (from g in _context.Groups
                          where g.Id == gId && teacher.Id == g.TeacherId
                          select new GroupDto()
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
                          }).AsSingleQuery().ToArrayAsync();
        }

        public async Task<IEnumerable<CourseDto>> GetTeachingGroups(int uId)
        {
            var teacher = await GetTeacher(uId);
            return await (from g in _context.Groups
                          join c in _context.Courses on g.CourseId equals c.Id
                          where g.TeacherId == teacher.Id
                          select new CourseDto()
                          {
                              Id = c.Id,
                              Name = c.Name,
                              Groups = (from g in c.Groups
                                        select new GroupDto()
                                        {
                                            Id = g.Id,
                                            GroupName = g.Group_name,
                                        }).ToList()
                          }).AsSingleQuery().ToArrayAsync();
        }

        public async Task<bool> UpdateGroupContent(Group group, int uId)
        {
            // int gId = group.
            // var teacher = await GetTeacher(uId);
            // var group = await _context.Groups.Include(g => g.Teacher).FirstAsync(g => g.Teacher.UserId == uId && g.gId == );
            return true;
        }
    }
}