using System;
using System.Collections.Generic;

namespace RESTfulAPI.Dto
{
    public interface IBlackSmithUpdate
    {
        public Guid Id { get; set; }
        DateTime? BirthDate { get; set; }
        string Description { get; set; }
        string Guild { get; set; }
        string Name { get; set; }
        string Race { get; set; }
        List<SwordDto> Swords { get; set; }
    }
}