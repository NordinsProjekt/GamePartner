using Domain.MtGDomain.DTO;
using MtGDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestForSolution._0._4_Domain.Models
{
    [Trait("Domain", "UseCardAsCommander")]
    public class UseCardAsCommander_Test
    {
        [Fact]
        public void CheckIfCardWillBeCommander_SendInNotValidCommander_IsModelValidShouldReturnFalse()
        {
            MtGCardRecordDTO card = new("TestCard", "111", "Def", new(), new(), "", "", 
                new string[] { "Instant" }, new string[] { "Legendary" });
            UseCardAsCommander commander = new(card);
            Assert.False(commander.IsModelValid());
        }

        [Fact]
        public void CheckIfCardWillBeCommander_SendInValidCommander_IsModelValidShouldReturnTrue()
        {
            MtGCardRecordDTO card = new("TestCard", "111", "Def", new(), new(), "", "",
                new string[] { "Creature" }, new string[] { "Legendary" });
            UseCardAsCommander commander = new(card);
            Assert.True(commander.IsModelValid());
        }
    }
}
