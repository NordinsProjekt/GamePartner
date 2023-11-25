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
        public DbSet<CardType> CardType { get; set; }
        public DbSet<SuperCardType> SuperCardTypes { get; set; }
        public DbSet<MagicAbility> MagicAbility { get; set; }
        public DbSet<MagicLegality> MagicLegality { get; set; }

        // DbSets for relationship tables
        public DbSet<CardTypeMagicCard> CardTypeMagicCards { get; set; }
        public DbSet<MagicAbilityMagicCard> MagicAbilityMagicCards { get; set; }
        public DbSet<MagicCardMagicLegality> MagicCardMagicLegalities { get; set; }
        public DbSet<MagicCardSuperCardType> MagicCardSuperCardTypes { get; set; }
        public DbSet<MagicSetMagicCard> MagicSetMagicCards { get; set; }
    }
}
