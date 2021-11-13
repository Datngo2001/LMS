using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TeacherName { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<LessonDto> Lessons { get; set; }
    }
}