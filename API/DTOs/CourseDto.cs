using System.Collections.Generic;

namespace API.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Credits { get; set; }
        public ICollection<GroupDto> Groups { get; set; }
        public int majorId { get; set; }
    }
}
