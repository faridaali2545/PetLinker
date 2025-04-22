using System;
using System.ComponentModel.DataAnnotations;

namespace PetLinker.Models
{
    public class MarketPlaceEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        public string? StoreName { get; set; }

        [MaxLength(250)]
        public string? Location { get; set; }

        [MaxLength(250)]
        public string? ContactInfo { get; set; }

        [MaxLength(250)]
        public string? Products { get; set; }

        [MaxLength(2500)]
        public string? Description { get; set; }

        [MaxLength(250)]
        public string? OpeningHours { get; set; }

        [MaxLength(250)]
        public string? PaymentMethods { get; set; }
    }
}
