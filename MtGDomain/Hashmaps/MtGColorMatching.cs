using MtGDomain.Constants;
using MtGDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.Hashmaps
{
    public static class MtGColorMap
    {
        public static readonly Dictionary<MtGColor, string> Values = new Dictionary<MtGColor, string>
        {
            { MtGColor.Black, MtGColorAsChar.Black },
            { MtGColor.White, MtGColorAsChar.White },
            { MtGColor.Red, MtGColorAsChar.Red },
            { MtGColor.Green, MtGColorAsChar.Green },
            { MtGColor.Blue, MtGColorAsChar.Blue },
        };
    }
}
