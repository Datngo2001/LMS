using System.Collections.Generic;

namespace API.DTOs.DashBoardComponent
{
    public class CourseCardDto
    {
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string Progress { get; set; }
        public string Group_name { get; set; }
        public ICollection<string> GroupUrls { get; set; }
    }
}