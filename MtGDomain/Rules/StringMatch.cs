using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.Rules
{
    public class StringMatch : IRequirement
    {
        private string Value { get; set; }
        public StringMatch(string value) { Value = value; }

        public bool Validate(object obj)
        {
            if (obj.GetType() == typeof(string))
                return ((string)obj).ToLower() == Value.ToLower();
            if (obj.GetType().IsArray == true && obj.GetType() == typeof(string))
            {
                string[] text = (string[])obj;
                foreach (var s in text)
                {
                    if (Value.ToLower() == s.ToLower())
                    { return true; }
                }
            }
            return false;
        }
    }
}
