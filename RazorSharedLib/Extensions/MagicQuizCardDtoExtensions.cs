using MtGDomain.Enums;
using MtGDomain.Extensions;
using RazorSharedLib.Api;

namespace RazorSharedLib.Extensions;

public static class MagicQuizCardDtoExtensions
{
    public static MtGColor GetColorFromCard(this MagicQuizCardDto card)
    {
        string[] arrayOfColors = ["B", "G", "U", "W", "R"];

        return arrayOfColors.Where(t => card.Color.Contains(t))
            .Aggregate(MtGColor.None, (current, t) =>
                current | EnumExtensions.GetColorFromDescription(t));
    }
}