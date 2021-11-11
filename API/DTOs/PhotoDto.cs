using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class PhotoDto
    {
        [Key]
        public int pId { get; set; }
        public string Url { get; set; }
        public int ContentId { get; set; }
    }
}