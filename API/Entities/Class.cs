using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Class
    {
        [Key]
        public int clId { get; set; }

        [Required]
        public string Class_name { get; set; }

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
    }
}
