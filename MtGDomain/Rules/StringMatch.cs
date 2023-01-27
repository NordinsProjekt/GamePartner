using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.Rules
{
    public class StringMatch : IRequirement
    {
        private object Value { get; set; }
        public StringMatch(string value) { Value = value; }

        public bool Validate(object obj)
        {
            if (obj.GetType() == typeof(string))
                return ((string)obj).ToLower() == ((string)Value).ToLower();
            if (obj.GetType().IsArray == true)
            {
                dynamic text = obj;
                foreach (var s in text)
                {
                    if (((string)Value).ToLower() == ((string)(s)).ToLower())
                    { return true; }
                }
            }
            return false;
        }
    }
}
