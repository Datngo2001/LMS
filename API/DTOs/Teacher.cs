using System;
using System.Collections.Generic;

namespace API.DTOs
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public string Picture { get; set; }
        public string Cmnd { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;
        public ICollection<GroupDto> Groups { get; set; }
        public int UserId { get; set; }
        public int FacultyId { get; set; }
    }
}