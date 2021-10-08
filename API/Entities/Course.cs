using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Credits { get; set; }



    }
}
