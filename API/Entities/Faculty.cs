using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Faculty
    {
        [Key]
        public int fId { get; set; }
        public string Name { get; set; }
        public ICollection<Major> Majors { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }
}
