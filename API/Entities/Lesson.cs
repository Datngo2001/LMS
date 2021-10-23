﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Lesson
    {
        [Key]
        public int lId { get; set; }

        public int Order { get; set; }

        public Group group { get; set; }

        public int groupId { get; set; }

        public ICollection<Content> Contents { get; set; }
    }
}
