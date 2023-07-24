using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.DTO
{
    public class MtGFormatFilter
    {
        public string FormatName { get; set; }
        public string ChoosenValue { get; set; } = "";
        public string[] Formats = new string[]
        {
            "Standard","Pioneer","Modern","Legacy","Vintage"
        };
    }
}
