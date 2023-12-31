using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.Entities
{
    public class MagicSetMagicCard
    {
        public Guid Id { get; set; }
        public Guid MagicSetId { get; set; }
        public MagicSet MagicSet { get; set; }

        public Guid MagicCardId { get; set; }
        public MagicCard MagicCard { get; set; }
    }
}
