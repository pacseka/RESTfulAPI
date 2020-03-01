using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RESTfulAPI.Infrastructure.Models
{
    public class BlackSmith
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string Description { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Guild { get; set; }

        public virtual List<Sword> Swords { get; set; }
    }
}
