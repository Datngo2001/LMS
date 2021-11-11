using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs.CourseComponent;
using API.DTOs.DashBoardComponent;
using API.Entities;

namespace API.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<CourseCardDto>> GetEnrolledCourse(int userId);
        Task<CourseDto> LoadCourseContent(int gId);
        Task<bool> isEnrolled(int uId, int gId);
        Task<bool> isCourseExist(String name);
        Task<bool> AddCourse(Course course);
        Task<bool> UpdateCourse(Course course);
        Task<bool> DeleteCourse(Course course);
    }
}