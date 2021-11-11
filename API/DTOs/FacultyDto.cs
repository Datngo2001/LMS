using System.Collections.Generic;

namespace API.DTOs
{
    public class FacultyDto
    {
        public int fId { get; set; }
        public string Name { get; set; }
        public ICollection<MajorDto> Majors { get; set; }
        public ICollection<TeacherDto> Teachers { get; set; }
    }
}
