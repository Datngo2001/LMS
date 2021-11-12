

namespace API.DTOs
{
    public class ContentDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public int LessonlId { get; set; }
    }
}