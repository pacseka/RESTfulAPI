using RESTfulAPI.DTO;
using System;

namespace RESTfulAPI.Dto
{
    public interface ISwordUpdate
    {
        Guid? BlackSmithId { get; set; }
        string BlackSmithName { get; set; }
        string BlackSmithRace { get; set; }
        DateTime? CreatedDate { get; set; }
        string Description { get; set; }
        Guid Id { get; set; }
        int LengthCm { get; set; }
        string Name { get; set; }
        Status Status { get; set; }
        string Type { get; set; }
        decimal WeightKg { get; set; }
    }
}