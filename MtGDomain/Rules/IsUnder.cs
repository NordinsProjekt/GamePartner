using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.Rules
{
    public class IsUnder : IRequirement
    {
        private object Value { get; set; }
        public IsUnder(int value) { Value = value; }
        public IsUnder(decimal value) { Value = value; }

        public bool Validate(object obj)
        {
            if (obj.GetType() == typeof(int))
                return (int)Value > (int)obj;
            if (obj.GetType() == typeof(decimal))
                return (decimal)Value > (decimal)obj;
            return false;
        }
    }
}
