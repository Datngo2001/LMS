using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class VideoDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
        public int ContentId { get; set; }
    }
}