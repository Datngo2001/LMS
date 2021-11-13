using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class CreateLessonDto
    {
        public int Order { get; set; }
        public string Name { get; set; }
        public int courseId { get; set; }
    }
}