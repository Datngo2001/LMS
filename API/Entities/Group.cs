using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Group_name { get; set; }
        public string Start_date { get; set; }
        public string End_date { get; set; }
        public string Lecturer { get; set; }
        public int Enroll_slot { get; set; }
        public string Term { get; set; }
        public string TotalTime { get; set; }
        public int Total_slot { get; set; }
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
        public ICollection<Enrolled> Enrolleds { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
    }
}
