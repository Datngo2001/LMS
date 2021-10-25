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
        public AssignmentDto Assignment { get; set; }
        public string PhotoUrl { get; set; }
        public string VideoUrl { get; set; }
        public string FileUrl { get; set; }
    }
}