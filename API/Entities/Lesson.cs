using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Lesson
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public Course course { get; set; }
        public int courseId { get; set; }
        public Video Video { get; set; }
    }
}
