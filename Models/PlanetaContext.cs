using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace ActividadApiPlanetas.Models
{
    public class PlanetaContext : DbContext
    {
        public PlanetaContext(DbContextOptions<PlanetaContext> options)
            : base(options)
        {
        }

        public DbSet<PlanetaItem> PlanetaItem { get; set; } = null!;
    }
}
