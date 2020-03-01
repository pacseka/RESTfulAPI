using System;
using System.ComponentModel.DataAnnotations;

namespace RESTfulAPI.DTO
{
    public class UpsertBlackSmith
    {
        [Required]
        public string Name { get; set; }

        public string Race { get; set; }

        public string Description { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Guild { get; set; }
    }
}
