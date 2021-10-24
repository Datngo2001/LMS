using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.CourseComponent
{
    public class ContentDto
    {
        public int cId { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AssignmentDto assignment { get; set; }
        public PhotoDto photo { get; set; }
        public VideoDto video { get; set; }
        public FileDto file { get; set; }
    }
}