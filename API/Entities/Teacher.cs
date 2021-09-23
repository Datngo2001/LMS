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
        public byte[] Picture { get; set; }

        [Required]
        public string Cmnd { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public DateTime Start_date { get; set; }


        public Account Account { get; set; }
        public int AccountId { get; set; }

    }
}