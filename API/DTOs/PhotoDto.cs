using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class PhotoDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int courseId { get; set; }
    }
}