using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class LessonDto
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public int courseId { get; set; }
        public string VideoPublicId { get; set; }
    }
}