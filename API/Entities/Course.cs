using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Credits { get; set; }
        public ICollection<Group> Groups { get; set; }
        public Major major { get; set; }
        public int majorId { get; set; }
    }
}
