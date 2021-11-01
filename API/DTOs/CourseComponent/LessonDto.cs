using System.Collections.Generic;
using API.Entities;

namespace API.DTOs
{
    public class LessonDto
    {
         public int cId { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }

        public Lesson Lesson { get; set; }

    }
}