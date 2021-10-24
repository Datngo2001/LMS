using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs.CourseComponent;

namespace API.Interfaces
{
    public interface IGroupRepository
    {
        Task<ICollection<GroupDto>> GetEnrolledGroupAsync(int userId);
        Task<ICollection<GroupDto>> GetGroupByCourse(int courseId);
    }
}