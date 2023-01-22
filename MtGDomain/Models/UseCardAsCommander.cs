using Domain.MtGDomain.DTO;
using MtGDomain.Base;
using MtGDomain.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.Models
{
    public class UseCardAsCommander : BaseValidate
    {
        private string[] Types;
        private string[] SuperTypes;
        public UseCardAsCommander(MtGCardRecordDTO card) 
        {
            if (card.Types == null)
                IsValid = false;
            else
                Types = card.Types.ToArray();

            if (card.SuperTypes == null)
                IsValid= false;
            else
                SuperTypes = card.SuperTypes.ToArray();
        }

        public override bool IsModelValid()
        {
            SetRules();
            base.Validate(this);
            return IsValid;
        }

        public override void SetRules()
        {
            Rules.Add(new Rule("Types", new() { new StringMatchExact("Creature") }));
            Rules.Add(new Rule("SuperTypes", new() { new StringMatchExact("Legendary") }));
        }
    }
}
