using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Enrolled
    {
        public int Id { get; set; }
        public AppUser appUser { get; set; }
        public int appUserId { get; set; }
        public Course course { get; set; }
        public int courseId { get; set; }
    }
}
