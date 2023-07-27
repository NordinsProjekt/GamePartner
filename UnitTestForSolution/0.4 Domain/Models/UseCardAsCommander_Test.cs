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
            MtGCardRecordDTO card = new MtGCardObject() { SuperTypes = new string[] { "" } }.GetDTO();
            UseCardAsCommander commander = new(card);
            Assert.False(commander.IsModelValid());
        }

        [Fact]
        public void CheckIfCardWillBeCommander_SendInValidCommander_IsModelValidShouldReturnTrue()
        {
            MtGCardRecordDTO card = new MtGCardObject() { Types = new string[] { "Creature" }, 
                SuperTypes = new string[] { "Legendary" } }.GetDTO();
            UseCardAsCommander commander = new(card);
            Assert.True(commander.IsModelValid());
        }
    }
}
