using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.CourseComponent
{
    public class GroupDto
    {
        public int gId { get; set; }

        public string Group_name { get; set; }

        public string Start_date { get; set; }

        public string End_date { get; set; }

        public string Lecturer { get; set; }

        public int Enroll_slot { get; set; }

        public string Term { get; set; }

        public string TotalTime { get; set; }

        public int Total_slot { get; set; }

        public int CourseId { get; set; }

        public ICollection<LessonDto> Lesson { get; set; }
    }
}