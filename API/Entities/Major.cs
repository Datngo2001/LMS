using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Major
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Faculty Faculty { get; set; }

        public int FacultyId { get; set; }


    }
}
