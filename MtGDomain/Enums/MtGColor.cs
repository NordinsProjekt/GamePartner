using System.ComponentModel;

namespace MtGDomain.Enums;

[Flags]
public enum MtGColor
{
    [Description("")] None = 0,
    [Description("B")] Black = 1,
    [Description("U")] Blue = 2,
    [Description("R")] Red = 4,
    [Description("W")] White = 8,
    [Description("G")] Green = 16
}