using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Video
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
        public Lesson Lesson { get; set; }
        public int lessonId { get; set; }
    }
}