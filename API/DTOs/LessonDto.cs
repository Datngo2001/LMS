using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class LessonDto
    {
        public int Id { get; set; }

        public int Order { get; set; }

        public string Name { get; set; }

        public GroupDto group { get; set; }

        public int groupId { get; set; }

        public ICollection<ContentDto> Contents { get; set; }
    }
}
