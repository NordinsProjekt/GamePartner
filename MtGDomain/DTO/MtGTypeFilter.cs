using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.DTO
{
    public class MtGTypeFilter
    {
        public string ChoosenValue { get; set; } = "";
        public string[] Types = new string[]
        {
            "Creature","Instant","Sorcery","Enchantment","Artefact", "Planeswalker", "Battle", "Saga"
        };
    }
}
