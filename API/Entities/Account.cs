using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Account
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string Role { get; set; }
    }
}