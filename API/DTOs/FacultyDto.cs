using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class FacultyDto
    {
        public int fId { get; set; }
        public string Name { get; set; }
        public ICollection<MajorDto> Majors { get; set; }
    }
}