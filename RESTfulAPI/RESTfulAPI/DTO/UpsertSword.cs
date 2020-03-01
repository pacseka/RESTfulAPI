using System;
using System.ComponentModel.DataAnnotations;

namespace RESTfulAPI.DTO
{
    public class UpsertSword
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public Guid BlackSimthId { get; set; }

        public decimal WeightKg { get; set; }

        public int LengthCm { get; set; }

        public DateTime CreatedDate { get; set; }

        public Status Status { get; set; }
    }
}
