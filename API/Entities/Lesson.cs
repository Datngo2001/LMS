using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Lesson
    {
        [Key]
        public int lId { get; set; }

        public int Order { get; set; }

        public int Content { get; set; }
    }
}
