using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.Entities
{
    public class MagicSet
    {
        public Guid Id { get; set; }
        public string SetName { get; set; }
        public string SetCode { get; set; }
        ICollection<MagicCard> MagicCards { get; set; }
    }
}
