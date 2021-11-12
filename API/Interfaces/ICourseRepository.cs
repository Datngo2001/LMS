using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<CourseDto>> GetEnrolledCourse(int userId);
        Task<CourseDto> LoadCourseContent(int gId);
        Task<bool> isStudentEnrolled(int uId, int gId);
        Task<bool> isCourseExist(Course course);
        Task<bool> AddCourse(Course course);
        Task<bool> UpdateCourse(Course course);
        Task<bool> DeleteCourse(Course course);
    }
}