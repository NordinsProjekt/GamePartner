using Domain.MtGDomain.DTO;
using MtGDomain.Models;

namespace UnitTestForSolution._0._4_Domain.Models
{
    [Trait("Domain", "UseCardAsCommander")]
    public class UseCardAsCommander_Test
    {
        [Fact]
        public void CheckIfCardWillBeCommander_SendInNotValidCommander_IsModelValidShouldReturnFalse()
        {
            MtGCardRecordDTO card = new("TestCard", "111", "Def", new(), new(), "", "", 
                new string[] { "Instant" }, new string[] { "Legendary"},0, false, false, "{1}{B}", "", "");
            UseCardAsCommander commander = new(card);
            Assert.False(commander.IsModelValid());
        }

        [Fact]
        public void CheckIfCardWillBeCommander_SendInValidCommander_IsModelValidShouldReturnTrue()
        {
            MtGCardRecordDTO card = new("TestCard", "111", "Def", new(), new(), "", "",
                new string[] { "Creature" }, new string[] { "Legendary"}, 0, false, false, "{1}{B}", "", "");
            UseCardAsCommander commander = new(card);
            Assert.True(commander.IsModelValid());
        }
    }
}
