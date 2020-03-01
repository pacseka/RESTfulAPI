using RESTfulAPI.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace RESTfulAPI.Infrastructure.Models
{
    public class Sword
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public virtual Guid? BlackSmithId { get; set; }
        public virtual BlackSmith BlackSmith { get; set; }
        public decimal WeightKg { get; set; }
        public int LengthCm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Status Status { get; set; }

    }
}
