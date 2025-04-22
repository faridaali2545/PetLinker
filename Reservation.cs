using System;
using System.ComponentModel.DataAnnotations;

namespace PetLinker.Models
{
    public class Reservation
    {

        [Key]
        public int Id { get; set; }


        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;


        [Required]
        [Phone]
        [MaxLength(15)]
        public string Phone { get; set; } = string.Empty;

        public required String Date { get; set; }


        public string? Description { get; set; }
    }
}