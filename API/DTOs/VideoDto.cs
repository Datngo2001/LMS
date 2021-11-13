using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class VideoDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int lessonId { get; set; }
    }
}