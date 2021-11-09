using System.Collections.Generic;
using API.DTOs.CourseComponent;
using API.Entities;

namespace API.DTOs.CourseComponent
{
    public class LessonDto
    {
        public int lId { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public List<ContentDto> Contents { get; set; }
    }
}