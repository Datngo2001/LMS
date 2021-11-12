
namespace API.Entities
{
    public class Content
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Photo Photos { get; set; }
        public Video Videos { get; set; }
        public File Files { get; set; }
        public Lesson Lesson { get; set; }
        public int LessonlId { get; set; }
    }
}