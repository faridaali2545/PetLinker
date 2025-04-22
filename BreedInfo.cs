using System.ComponentModel.DataAnnotations;

namespace PetLinker.Models
{
    public class BreedInfo
    {
        [Key]
        public int Id { get; set; }

        public required string PetType { get; set; }

        public required string Breed { get; set; }

        public required string Description { get; set; }

        public string? ImageUrl{ get; set; }

    }
}
