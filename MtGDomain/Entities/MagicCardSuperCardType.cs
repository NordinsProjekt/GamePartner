using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.Entities
{
    public class MagicCardSuperCardType
    {
        public Guid Id { get; set; }
        public Guid MagicCardId { get; set; }
        public MagicCard MagicCard { get; set; }

        public Guid SuperCardTypeId { get; set; }
        public SuperCardType SuperCardType { get; set; }
    }
}
