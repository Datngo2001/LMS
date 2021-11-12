using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
        public Course Course { get; set; }
        public int courseId { get; set; }
    }
}