using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string  Address { get; set; }
    }
}