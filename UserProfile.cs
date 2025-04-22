using System.ComponentModel.DataAnnotations;

namespace PetLinker.Models
{
    public class UserProfile
    {
        [Key]
        [MaxLength(25)]
        public required string Username { get; set; }

        [MaxLength(25)]
        public required string Password { get; set; }

        [MaxLength(50)]
        public required string Email { get; set; }

        [MaxLength(20)]
        public string Status { get; set; } = string.Empty;

        [MaxLength(2500)]
        public string Feedback { get; set; } = string.Empty;
    }
}
