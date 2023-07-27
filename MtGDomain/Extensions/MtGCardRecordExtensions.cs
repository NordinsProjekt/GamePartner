using Domain.MtGDomain.DTO;
using MtGDomain.Constants;
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
    }
}
