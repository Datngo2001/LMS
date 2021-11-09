
using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.CourseComponent
{
    public class GroupDto
    {
        public int GId { get; set; }
        public string GroupName { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string Lecturer { get; set; }

        public int EnrollSlot { get; set; }

        public string Term { get; set; }

        public string TotalTime { get; set; }

        public int TotalSlot { get; set; }

        public List<LessonDto> Lessons { get; set; }
    }
}

