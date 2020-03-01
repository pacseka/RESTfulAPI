using System;
using System.Collections.Generic;

namespace RESTfulAPI.Dto
{
    public class BlackSmithDto : IBlackSmithUpdate
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Race { get; set; }

        public string Description { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Guild { get; set; }

        public List<SwordDto> Swords { get; set; }

    }
}