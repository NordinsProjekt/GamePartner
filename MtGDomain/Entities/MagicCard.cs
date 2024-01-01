using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.Entities
{
    public class MagicCard
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CardId { get; set; }
        public string Text { get; set; }
        public ICollection<MagicRuling> Rulings { get; set; }
        public Guid MagicSetId { get; set; }
        public MagicSet MagicSet { get; set; }
        public ICollection<MagicAbilityMagicCard> Abilities { get; set; }
        public string ImageUrl { get; set; }
        public string MultiverseId { get; set; }
        public ICollection<CardTypeMagicCard> CardTypes { get; set; }
        public ICollection<CardSubTypeMagicCard> CardSubTypes { get; set; }
        public ICollection<MagicCardSuperCardType> SuperCardTypes { get; set; }
        public int Cmc { get; set; }
        public bool IsColorLess { get; set; }
        public bool IsMultiColor { get; set; }
        public string ManaCost { get; set; }
        public string CollectingNumber { get; set; }
        public ICollection<MagicCardMagicLegality> MagicLegalities { get; set; }
    }
}