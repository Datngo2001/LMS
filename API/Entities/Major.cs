using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Major
    {
        [Key]
        public int mId { get; set; }

        [Required]
        public string Name { get; set; }

        public Faculty Faculty { get; set; }

        public int FacultyId { get; set; }


    }
}
