using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.Teacher;
using API.Interfaces;
using API.Entities;
using Microsoft.EntityFrameworkCore;

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
            Course course = await _context.Courses.Include(c => c.Groups).FirstOrDefaultAsync(c => c.cId == group.CourseId);
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
            var group = await _context.Groups.Include(g => g.Teacher).FirstAsync(g => g.Teacher.UserId == uId && g.gId == gId);
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
                          where g.gId == gId && teacher.Id == g.TeacherId
                          select new GroupDto()
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
                          }).AsSingleQuery().ToArrayAsync();
        }

        public async Task<IEnumerable<CourseDto>> GetTeachingGroups(int uId)
        {
            var teacher = await GetTeacher(uId);
            return await (from g in _context.Groups
                          join c in _context.Courses on g.CourseId equals c.cId
                          where g.TeacherId == teacher.Id
                          select new CourseDto()
                          {
                              cId = c.cId,
                              Name = c.Name,
                              Groups = (from g in c.Groups
                                        select new GroupDto()
                                        {
                                            GId = g.gId,
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