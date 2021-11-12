using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Lesson
    {
        public int Id { get; set; }

        public int Order { get; set; }

        public string Name { get; set; }

        public Group group { get; set; }

        public int groupId { get; set; }

        public ICollection<Content> Contents { get; set; }
    }
}
