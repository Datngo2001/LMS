using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class GroupDto
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Lecturer { get; set; }
        public int EnrollSlot { get; set; }
        public string Term { get; set; }
        public string TotalTime { get; set; }
        public int TotalSlot { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public ICollection<LessonDto> Lessons { get; set; }
    }
}
