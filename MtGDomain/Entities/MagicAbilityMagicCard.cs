using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.Entities
{
    public class MagicAbilityMagicCard
    {
        public Guid Id { get; set; }
        public Guid MagicAbilityId { get; set; }
        public Guid MagicCardId { get; set; }
    }
}
