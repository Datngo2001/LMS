using System.Collections.Generic;

namespace API.DTOs
{
    public class MajorDto
    {
        public int mId { get; set; }
        public string Name { get; set; }
        public ICollection<CourseDto> Courses { get; set; }
        public int FacultyId { get; set; }
    }
}
