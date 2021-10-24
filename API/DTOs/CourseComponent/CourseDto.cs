using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.CourseComponent
{
    public class CourseDto
    {
        public int cId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Credits { get; set; }

        public ICollection<GroupDto> Groups { get; set; }
    }
}