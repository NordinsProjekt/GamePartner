using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_Service.DTO
{
    public class MtGSearchFilter
    {
        public bool Creature { get; set; }
        public bool Enchantment { get; set; }
        public bool Instant { get; set; }
        public bool Sorcery { get; set; }
        public bool Artefact { get; set; }
        public bool Battle { get; set; }
        public bool Planeswalker { get; set; }
        public bool Land { get; set; }
    }
}
