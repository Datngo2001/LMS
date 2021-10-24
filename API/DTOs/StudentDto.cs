using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class StudentDto
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Picture { get; set; }

        public string Phone { get; set; }

        public string Cmnd { get; set; }

        public string Birthday { get; set; }

        public string Address { get; set; }

        public string Major { get; set; }

        public string Class { get; set; }

        public string Start_date { get; set; }

        public string Username { get; set; }
    }
}