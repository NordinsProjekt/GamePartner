using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.Entities
{
    public class MagicCardMagicLegality
    {
        public Guid Id { get; set; }
        public Guid MagicCardId { get; set; }
        public MagicCard MagicCard { get; set; }

        public Guid MagicLegalityId { get; set; }
        public MagicLegality MagicLegality { get; set; }
    }
}
