using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.Entities
{
    public class SuperCardType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<MagicCardSuperCardType> MagicCards { get; set; }
    }
}
