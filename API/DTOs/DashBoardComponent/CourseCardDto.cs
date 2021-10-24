using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.DashBoardComponent
{
    public class CourseCardDto
    {
        public int cId { get; set; }
        public string Name { get; set; }
        public string Start_date { get; set; }
        public string End_date { get; set; }
        public int gId { get; set; }
        public string Group_name { get; set; }
    }
}