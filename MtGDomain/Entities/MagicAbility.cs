using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.Entities
{
    public class MagicAbility
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<MagicCard> Cards { get; set; }
    }
}
