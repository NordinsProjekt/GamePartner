using MtGDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.DTO
{
    public class MtGColorFilter
    {
        public bool Black { get; set; }
        public bool White { get; set; }
        public bool Green { get; set; }
        public bool Blue { get; set; }
        public bool Red { get; set; }

        public List<MtGColor> GetListOfColors()
        {
            var list = new List<MtGColor>();
            if (Black)
                list.Add(MtGColor.Black);
            if (White)
                list.Add(MtGColor.White);
            if (Red)
                list.Add(MtGColor.Red);
            if (Green)
                list.Add(MtGColor.Green);
            if (Blue)
                list.Add(MtGColor.Blue);
            return list;
        }
    }
}
