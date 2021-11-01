using API.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class CourseDto
    {
        public int cId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Credits { get; set; }

    }
}
