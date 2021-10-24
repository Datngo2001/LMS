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
        public AssignmentDto Link { get; set; }
        public ICollection<PhotoDto> Photos { get; set; }
        public ICollection<VideoDto> Videos { get; set; }
        public ICollection<FileDto> Files { get; set; }
    }
}