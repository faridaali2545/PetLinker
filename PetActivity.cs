using System;
using System.ComponentModel.DataAnnotations;

namespace PetLinker
{
    public class PetActivity
    {
        [Key]
        public int ActivityNumber { get; set; }

        [Required]
        [MaxLength(255)]
        public string ActivityName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string ActivityType { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string Location { get; set; } = string.Empty;

        public string? Description { get; set; }


        [MaxLength(20)]
        public string? ContactInfo { get; set; }
    }
}
