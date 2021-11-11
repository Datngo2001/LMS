using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Enrolled
    {
        [Key]
        public int Id { get; set; }

        public Student Student { get; set; }
        public int StudentId { get; set; }

        public Group group { get; set; }
        public int groupId { get; set; }
    }
}
