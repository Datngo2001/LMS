using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.DTOs.CourseComponent;
using API.Interfaces;

namespace API.Data
{
    public class GroupRepository //s: IGroupRepository
    {
        public Task<ICollection<GroupDto>> GetEnrolledGroupAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<GroupDto>> GetGroupByCourse(int courseId)
        {
            throw new NotImplementedException();
        }
    }
}