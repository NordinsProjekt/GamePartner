using Microsoft.EntityFrameworkCore;
using MtGDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicRepositories
{
    public class PortalContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=Portal;user=root;password=");
        }

        public DbSet<MagicCard> MagicCards { get; set; }
        public DbSet<MagicSet> MagicSets { get; set; }
        public DbSet<MagicLegality> MagicLegality { get; set; }
    }
}
