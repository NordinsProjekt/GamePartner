using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.Entities
{
    public class CardTypeMagicCard
    {
        public Guid Id { get; set; }
        public Guid CardTypeId { get; set; }
        public CardType CardType { get; set; }

        public Guid MagicCardId { get; set; }
        public MagicCard MagicCard { get; set; }
    }
}
