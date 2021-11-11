using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Major
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }

        public Faculty Faculty { get; set; }
        public int FacultyId { get; set; }
    }
}
