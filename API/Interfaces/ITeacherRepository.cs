using System;
using System.Collections.Generic;
using API.Entities;
using System.Threading.Tasks;
using API.DTOs.Teacher;

namespace API.Interfaces
{
    public interface ITeacherRepository
    {
        Task<bool> CreateGroup(Group group, int uId);
        Task<IEnumerable<CourseDto>> GetTeachingGroups(int uId);
        Task<IEnumerable<GroupDto>> GetGroupContent(int gId, int uId);
        Task<bool> UpdateGroupContent(Group group, int uId);
        Task<bool> DeleteGroup(int gId, int uId);
        Task<Teacher> GetTeacher(int uId);
    }
}