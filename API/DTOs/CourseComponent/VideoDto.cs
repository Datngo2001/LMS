using System.ComponentModel.DataAnnotations;

namespace API.DTOs.CourseComponent
{
    public class VideoDto
    {
        [Key]
        public int vId { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
        public int ContentId { get; set; }
    }
}