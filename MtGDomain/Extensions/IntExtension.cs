using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.Extension
{
    public static class IntExtension
    {
        public static int IsAbove(this int x, int y)
        {
            if (x > y) return x;
            throw new Exception(x + " Is not Above " + y);
        }

        public static int IsSame(this int x, int y)
        {
            if (x == y) return x;
            throw new Exception(x + " Is not same as " + y);
        }
    }
}
