using MtGDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestForSolution._0._4_Domain.Models
{
    [Trait("Domain", "CreatureAbility")]
    public class CheckIfCreatureAbilityExist_Test
    {
        public string Text = "First strike testing if hexproof also exists in this list " +
            "But sHRoud should also be in this. Should have count 3";

        [Fact]
        public void UseThePublicText_ShouldReturnListWith3items()
        {
            var result = CheckIfCreatureAbilityExist.GiveAbilityKeywordsFromText(Text);
            Assert.True(result.Count() == 3);
        }
    }
}
