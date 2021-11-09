using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.CourseComponent
{
    public class StudentDto
    {

        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public AppUser User { get; set; }

        public int UserId { get; set; }

    }
}
