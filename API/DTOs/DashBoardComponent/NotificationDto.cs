using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.DashBoardComponent
{
    public class NotificationDto
    {
        public string Type { get; set; }
        public string NotiUrl { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}