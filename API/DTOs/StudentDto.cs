using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class StudentDto
    {
        [Key]
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Gender { get; set; }

        public string Picture { get; set; }

        public string Phone { get; set; }

        public string Cmnd { get; set; }

        public DateTime Birthday { get; set; }

        public string Address { get; set; }

        public string Major { get; set; }

        public string Class { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
        
        public DateTime LastActive { get; set; } = DateTime.Now;

        public AppUser User { get; set; }

        public int UserId { get; set; }

        public ICollection<Enrolled> Enrolleds { get; set; }
    }
}
