using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.Rules
{
    public interface IRule
    {
        public string PropertyName { get; set; }
        public List<IRequirement> List { get; set; }
    }
}
