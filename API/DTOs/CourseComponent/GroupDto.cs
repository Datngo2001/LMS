using System;
using System.Collections.Generic;

namespace API.DTOs.CourseComponent
{
    public class GroupDto
    {
        public string Group_name { get; set; }
        public string Start_date { get; set; }
        public string End_date { get; set; }
        public string LecturerName { get; set; }
        public string LectureProfileUrl { get; set; }
        public int Enroll_slot { get; set; }
        public string Term { get; set; }
        public string TotalTime { get; set; }
        public int Total_slot { get; set; }
        public ICollection<LessonDto> Lessons { get; set; }
    }
}