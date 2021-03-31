using TechRadar.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace TechRadar.Api.Interfaces
{
    public interface ITechRadarDbContext
    {
        DbSet<Blip> Blips { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
