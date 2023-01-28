using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.Extension
{
    public static class StringExtension
    {
        public static string IsLongerThan(this string s, int number) 
        {
            if (s.Count() <= number)
                throw new Exception("String is not Longer than " +number);
            return s;
        }

        public static string ButMax(this string s, int max)
        {
            if (s.Count() > max)
                throw new Exception("String is longer than maximum size " + max);
            return s;
        }
    }
}
