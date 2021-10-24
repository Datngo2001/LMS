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
        public Assignment assignment { get; set; }
        public Photo photo { get; set; }
        public Video video { get; set; }
        public File file { get; set; }
    }
}