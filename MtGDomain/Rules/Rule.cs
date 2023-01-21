using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.Rules
{
    public class Rule : IRule
    {
        public string PropertyName { get; set; }
        public List<IRequirement> List { get; set; }
        public Rule(string propertyName, List<IRequirement> list) 
        { 
            PropertyName= propertyName;
            List = list;
        }
    }
}
