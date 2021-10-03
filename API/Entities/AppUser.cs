using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public string picture { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string bdate { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}