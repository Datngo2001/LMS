using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Enrolled
    {
        [Key]
        public int eId { get; set; }

        public Student Student { get; set; }
        public int StudentId { get; set; }

        public Class Class { get; set; }
        public int ClassId { get; set; }
    }
}
