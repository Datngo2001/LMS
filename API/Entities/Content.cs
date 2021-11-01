using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Content
    {
        [Key]
        public int cId { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<Video> Videos { get; set; }
        public ICollection<File> Files { get; set; }
        public Lesson Lesson { get; set; }
        public int LessonlId { get; set; }
    }
}