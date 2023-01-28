using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.Models
{
    public static class CheckIfCreatureAbilityExist
    {
        private static List<string> list = new()
        {
            "First strike",
            "Trample",
            "Lifelink",
            "Flying",
            "Swampwalk",
            "Mountainwalk",
            "Islandwalk",
            "Plainswalk",
            "Forestwalk",
            "Double strike",
            "Fear",
            "Shroud",
            "Unblockable",
            "Hexproof",
            "Infect"
        };
        public static bool Exists(string text)
            => list.Contains(text);
        public static IEnumerable<string> GiveAbilityKeywordsFromText(string text)
        {
            List<string> temp = new();
            foreach (var ability in list)
            {
                if (text.ToLower().Contains(ability.ToLower()))
                    temp.Add(ability); 
            }
            return temp;
        }

    }
}
