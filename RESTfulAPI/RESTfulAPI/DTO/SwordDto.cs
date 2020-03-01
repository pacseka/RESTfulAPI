using RESTfulAPI.DTO;
using System;


namespace RESTfulAPI.Dto
{
    public class SwordDto : ISwordUpdate
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public Guid? BlackSmithId { get; set; }
        public string BlackSmithName { get; set; }
        public string BlackSmithRace { get; set; }

        public decimal WeightKg { get; set; }

        public int LengthCm { get; set; }

        public DateTime? CreatedDate { get; set; }

        public Status Status { get; set; }
    }
}