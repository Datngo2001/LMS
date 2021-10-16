using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Enrolled
    {
        [Key]
        public int eId { get; set; }

        public Student Student { get; set; }
        public int StudentId { get; set; }

        public Classes Classes { get; set; }
        public int ClassesId { get; set; }
    }
}
