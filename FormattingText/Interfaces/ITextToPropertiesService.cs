namespace FormattingText.Interfaces;

public interface ITextToPropertiesService
{
    string[] StringToProperty(string Text, string split, string type);
}