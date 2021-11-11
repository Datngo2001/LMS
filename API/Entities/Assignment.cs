using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

    }
}