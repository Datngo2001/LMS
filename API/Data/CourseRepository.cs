using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.DashBoardComponent;
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
        public async Task<ICollection<CourseCardDto>> GetEnrolledCourse(int userId)
        {
            return await (from c in _context.Courses
                          join g in _context.Groups on c.cId equals g.gId
                          join e in _context.Enrolleds on g.gId equals e.eId
                          select new CourseCardDto()
                          {
                              cId = c.cId,
                              Name = c.Name,
                              Group_name = g.Group_name,
                              gId = g.gId
                          }).ToListAsync();
        }
    }
}