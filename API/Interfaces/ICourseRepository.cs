using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.DTOs.CourseComponent;
using API.DTOs.DashBoardComponent;

namespace API.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<CourseCardDto>> GetEnrolledCourse(int userId);
        Task<CourseDto> LoadCourseContent(int gId);
        Task<bool> isEnrolled(int uId, int gId);
    }
}