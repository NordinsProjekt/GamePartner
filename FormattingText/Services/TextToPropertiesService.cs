using FormattingText.Interfaces;

namespace FormattingText.Services;

public class TextToPropertiesService : ITextToPropertiesService
{
    public string[] StringToProperty(string text, string split, string type)
    {
        var temp = text.Split(split);
        return temp.Select(item => $"public {type} {item}" + " { get; set; };").ToArray();
    }
}