using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PlanetasApi.Models
{
    public class PlanetContext : DbContext
    {
        public PlanetContext(DbContextOptions<PlanetContext> options)
            : base(options)
        {
        }

        public DbSet<PlanetItem> PlanetItems { get; set; }

    }

}
