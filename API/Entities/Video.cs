using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Video
    {
        [Key]
        public int vId { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
        public Content Content { get; set; }
        public int ContentId { get; set; }
    }
}