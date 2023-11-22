using Microsoft.EntityFrameworkCore;
using MtGDomain.Entities;

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
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<SuperCardType> SuperCardTypes { get; set; }
        public DbSet<MagicAbility> Abilities { get; set; }
        public DbSet<MagicLegality> MagicLegalities { get; set; }
    }
}
