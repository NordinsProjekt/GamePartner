using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.Rules
{
    public class StringMatchExact : IRequirement
    {
        private object Value { get; set; }
        public StringMatchExact(string value) { Value = value; }

        public bool Validate(object obj)
        {
            if (obj.GetType() == typeof(string))
                return (string)obj == (string)Value;
            if (obj.GetType().IsArray == true)
            {
                dynamic text = obj;
                foreach (var s in text)
                {
                    if (Value == s)
                    { return true; }
                }
            }
            return false;
        }
    }
}
