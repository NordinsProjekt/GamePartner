
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using MtGDomain.Rules;

namespace MtGDomain.Base
{
    abstract public class BaseValidate
    {
        public List<IRule> Rules = new List<IRule>();
        protected bool IsValid { get; set; } = true;
        public bool WasValidated { get; private set; } = false;
        public List<string> Errors { get; private set; } = new List<string>();

        public bool Validate(object obj)
        {
            foreach (PropertyInfo propertyInfo in obj.GetType().GetProperties())
            {
                var namn = propertyInfo.Name;
                var rule = Rules.Where(x=>x.PropertyName== namn).FirstOrDefault();
                if (rule != null)
                {
                    foreach (var req in rule.List)
                    {
                        bool Valid = req.Validate(propertyInfo.GetValue(obj, null));
                        if (Valid == false)
                        {
                            Log($"Property: {namn} failed validation, rule "+req.GetType().Name);
                        }
                    }
                }
            }
            return true;
        }

        private void Log(string message)
        {
            Errors.Add(message);
            IsValid = false;
        }
        /// <summary>
        ///    SetRules();
        ///    base.Validate(this);
        ///    return IsValid;
        /// </summary>
        /// <returns>True/False</returns>
        abstract public bool IsModelValid();
        /// <summary>
        /// Rules.Add(new Rule("Age", new() { new IsAbove(5) }));
        /// </summary>
        abstract public void SetRules();
    }

}
