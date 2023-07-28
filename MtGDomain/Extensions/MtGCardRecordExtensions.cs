using Domain.MtGDomain.DTO;
using MtGDomain.Constants;
using MtGDomain.DTO;
using MtGDomain.Enums;
using MtGDomain.Hashmaps;

namespace MtGDomain.Extensions
{
    public static class MtGCardRecordExtensions
    {
        public static bool DoesCardHaveThisColor(this MtGCardRecordDTO card, MtGColor color)
        {
            var colorText = MtGColorMap.Values.GetValueOrDefault(color);
            if (colorText is not null && card.ManaCost is not null && card.ManaCost.Contains(colorText))
                return true;
            return false;
        }

        public static bool DoesCardHaveThisColor(this MtGCardRecordDTO card, List<MtGColor> color)
        {
            foreach (var item in color)
            {
                if (!card.DoesCardHaveThisColor(item))
                    return false;
            }
            return true;
        }

        public static bool FindSuperType(this MtGCardRecordDTO card, string supertype)
        {
            if (card.SuperTypes is null)
                return false;
            return card.SuperTypes.Contains(supertype);
        }
    }
}
