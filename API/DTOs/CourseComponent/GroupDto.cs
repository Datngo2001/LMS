using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class GroupDto
    {

        public string Group_name { get; set; }

        public string Start_date { get; set; }

        public string End_date { get; set; }

        public string Lecturer { get; set; }

        public int Enroll_slot { get; set; }

        public string Term { get; set; }
 
        public string TotalTime { get; set; }

        public int Total_slot { get; set; }

        public CourseDto Course {get; set;}
    }
}
