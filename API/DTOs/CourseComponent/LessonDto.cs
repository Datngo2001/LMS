using System.Collections.Generic;

namespace API.DTOs.CourseComponent
{
    public class LessonDto
    {
        public int lId { get; set; }

        public int Order { get; set; }

        public string Name { get; set; }
        
        public int groupId { get; set; }

        public ICollection<ContentDto> Contents { get; set; }
    }
}