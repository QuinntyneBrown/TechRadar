using TechRadar.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TechRadar.Api.Data
{
    public class BlipConfiguration: IEntityTypeConfiguration<Blip>
    {
        public void Configure(EntityTypeBuilder<Blip> builder)
        {
            
        }
        
    }
}
