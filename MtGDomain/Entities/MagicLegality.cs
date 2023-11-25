using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.Entities
{
    public class MagicLegality
    {
        public Guid Id { get; set; }
        public string Format { get; set; }
        public string LegalityName { get; set; }
        public ICollection<MagicCardMagicLegality> MagicCards { get; set; }
    }
}
