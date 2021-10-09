using System;
using System.ComponentModel.DataAnnotations;

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

        [Required]
        public string Picture { get; set; }

        [Required]
        public string Cmnd { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Birthday { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Start_date { get; set; }

        public AppUser User { get; set; }

        public int UserId { get; set; }

    }
}