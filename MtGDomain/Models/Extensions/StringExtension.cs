using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.Models.Extensions
{
    public static class StringExtension
    {
        public static string FirstCharToUpper(this string str)
        {
            return char.ToUpper(str[0])+str.Substring(1);
        }
    }
}
