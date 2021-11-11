using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace API.Entities
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        public string Gender { get; set; }
        [Required]
        public string Picture { get; set; }
        [Required]
        public string Cmnd { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public string Address { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;
        public ICollection<Group> Groups { get; set; }
        public AppUser User { get; set; }
        public int UserId { get; set; }
        public Faculty Faculty { get; set; }
        public int FacultyId { get; set; }
    }
}