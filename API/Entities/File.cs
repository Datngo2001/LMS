using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class File
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
        public Content Content { get; set; }
        public int ContentId { get; set; }
    }
}