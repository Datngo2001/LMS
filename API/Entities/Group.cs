using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Group
    {
        [Key]
        public int gId { get; set; }
        [Required]
        public string Group_name { get; set; }
        [Required]
        public string Start_date { get; set; }
        [Required]
        public string End_date { get; set; }
        [Required]
        public string Lecturer { get; set; }
        [Required]
        public int Enroll_slot { get; set; }
        [Required]
        public string Term { get; set; }
        [Required]
        public string TotalTime { get; set; }
        [Required]
        public int Total_slot { get; set; }
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
        public ICollection<Enrolled> Enrolleds { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
    }
}
