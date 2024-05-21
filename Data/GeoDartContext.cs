using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GeoDart.Models;

namespace GeoDart.Data
{
    public class GeoDartContext : DbContext
    {
        public GeoDartContext(DbContextOptions<GeoDartContext> options)
            : base(options)
        {
        }

        public DbSet<GeoDart.Models.Machine> Machine { get; set; } = default!;

        public DbSet<GeoDart.Models.DrillingData>? DrillingData { get; set; }
    }

}
