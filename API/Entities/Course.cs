using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AppUser Teacher { get; set; }
        public int TeacherId { get; set; }
        public Photo Photo { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
    }
}
