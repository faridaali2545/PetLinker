using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetLinker.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [MaxLength(10)]
        public required string Gender { get; set; }

        public required int Age { get; set; }

        [MaxLength(50)]
        public string HealthCondition { get; set; } = string.Empty;

        [MaxLength(50)]
        public required string Type { get; set; }

        [MaxLength(50)]
        public required string Breed { get; set; }

        [MaxLength(15)]
        public required string Status { get; set; }

        [MaxLength(50)]
        public string Location { get; set; } = string.Empty;

        [MaxLength(25)]
        public string? UserProfileUsername { get; set; }

        [ForeignKey("UserProfileUsername")]
        public UserProfile? UserProfile { get; set; }

    }
}
