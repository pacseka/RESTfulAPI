using Microsoft.EntityFrameworkCore;
using RESTfulAPI.Infrastructure.Models;
using System;

namespace RESTfulAPI.Infrastructure
{
    public class SwordContext : DbContext
    {
        public DbSet<Sword> Swords { get; set; }
        public DbSet<BlackSmith> BlackSimths { get; set; }

        public SwordContext()
        {

        }

        public SwordContext(DbContextOptions<SwordContext> options) : base(options)
        {
           
        }

    }
}
