using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Classes
    {
        public int Id { get; set; }

        [Required]
        public string Class_name { get; set; }

        [Required]
        public DateTime Start_date { get; set; }

        [Required]
        public DateTime End_date { get; set; }

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

        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}
