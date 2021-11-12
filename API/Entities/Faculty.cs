﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Major> Majors { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }
}
