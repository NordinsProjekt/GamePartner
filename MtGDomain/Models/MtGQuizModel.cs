using MtGDomain.Enums;

namespace MtGDomain.Models;

public class MtGQuizModel
{
    public MtGCardColor Color { get; set; } = new MtGCardColor();
    public QuizType Quiz { get; set; }
    public int CmcValue { get; set; }
    public string QuizSet { get; set; } = "";

    public MtGColor GetColorFromUser()
    {
        var colorMap = new Dictionary<Func<bool>, MtGColor>
        {
            { () => Color.Black, MtGColor.Black },
            { () => Color.Blue, MtGColor.Blue },
            { () => Color.Green, MtGColor.Green },
            { () => Color.White, MtGColor.White },
            { () => Color.Red, MtGColor.Red }
        };

        var userAnswer = colorMap.Where(pair => pair.Key())
            .Aggregate(MtGColor.None, (current, pair) => current | pair.Value);

        return userAnswer;
    }
}