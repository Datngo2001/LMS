using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.DashBoardComponent
{
    public class DeadLineDto
    {
        public string Type { get; set; }
        public string DeadLineUrl { get; set; }
        public string CourseName { get; set; }
        public string GroupName { get; set; }
        public string EndDate { get; set; }
        public string TimeRemaining { get; set; }
    }
}