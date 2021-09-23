using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Enrolled
    {
        public int Id { get; set; }

        public Student Student { get; set; }
        public int StudentId { get; set; }

        public Classes Classes { get; set; }
        public int ClassesId { get; set; }
    }
}
