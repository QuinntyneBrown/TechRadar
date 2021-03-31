using TechRadar.Api.Models;
using TechRadar.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TechRadar.Api.Data
{
    public class TechRadarDbContext: DbContext, ITechRadarDbContext
    {
        public DbSet<Blip> Blips { get; private set; }
        public TechRadarDbContext(DbContextOptions options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TechRadarDbContext).Assembly);
        }
        
    }
}
