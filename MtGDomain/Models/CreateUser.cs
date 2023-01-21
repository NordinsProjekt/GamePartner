using MtGDomain.Base;
using MtGDomain.Extension;
using MtGDomain.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.Models
{
    public class CreateUser
    {
        private string Name { get; set; }
        private int Age { get; set; }
        public CreateUser(string Name, int Age) 
        {
            this.Name = Name
                .IsLongerThan(10)
                .ButMax(40);
            this.Age = Age.IsAbove(5);
        }

        public int GetAge
        {
            get { return Age; }
        }
    }

    public class CreateUserWithRules : BaseValidate
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public bool IsModelValid()
        {
            SetRules();
            base.Validate(this);
            return IsValid;
        }

        public void SetRules()
        {
            Rules.Add(new Rule("Age", new() { new IsAbove(5) }));
        }
    }
}
