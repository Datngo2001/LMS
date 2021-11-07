using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.DashBoardComponent;

namespace API.Interfaces
{
    public interface ICourseRepository
    {
        Task<ICollection<CourseCardDto>> GetEnrolledCourse(int userId);
    }
}