using Domain.MtGDomain.DTO;
using MtGDomain.Constants;
using MtGDomain.Enums;

namespace MtGDomain.Extensions
{
    public static class MtGCardRecordExtensions
    {
        public static bool DoesCardHaveThisColor(this MtGCardRecordDTO card, MtGColor color)
        {
            switch(color)
            {
                case MtGColor.Black:
                    return card.ManaCost.Contains(MtGColorAsChar.Black);
                case MtGColor.White:
                    return card.ManaCost.Contains(MtGColorAsChar.White);
                case MtGColor.Red:
                    return card.ManaCost.Contains(MtGColorAsChar.Red);
                case MtGColor.Green:
                    return card.ManaCost.Contains(MtGColorAsChar.Green);
                case MtGColor.Blue:
                    return card.ManaCost.Contains(MtGColorAsChar.Blue);

                default: return false;
            }
        }
    }
}
