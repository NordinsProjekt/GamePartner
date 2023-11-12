using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.Entities
{
    public class MagicRuling
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
    }
}
