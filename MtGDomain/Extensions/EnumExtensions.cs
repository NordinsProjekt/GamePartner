using MtGDomain.Enums;
using System.ComponentModel;
using System.Reflection;

namespace MtGDomain.Extensions;

public static class EnumExtensions
{
    // Method to get the description of the enum value
    public static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        if (field == null) return "";

        return Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))
            is not DescriptionAttribute attribute
            ? value.ToString()
            : attribute.Description;
    }

    // New method to get the enum value from the description
    public static MtGColor GetColorFromDescription(string description)
    {
        return Enum.GetValues(typeof(MtGColor)).Cast<MtGColor>()
            .FirstOrDefault(color => color.GetDescription()
                .Equals(description, StringComparison.OrdinalIgnoreCase));
    }
}