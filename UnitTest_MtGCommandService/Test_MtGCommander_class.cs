using Application.MtGCard_Service.DTO;
using Domain.MtGDomain.DTO;
using MtGCard_Service.Classes;
namespace UnitTest_MtGCommanderService
{
    [Trait("Application", "MtGCommander class")]
    public class Test_MtGCommander_class
    {
        [Fact]
        public void TryToSetCommanderCard_WithAnAcceptedCard_ShouldReturnTheCard()
        {
            MtGCardRecordDTO card = new("Testcard", "1", "Testcard",new(), new(), "www.", "11", new string[] { "Creature" }, new string[] { "Legendary" });
            MtGCommander com = new();
            com.SetCommanderCard(card);
            Assert.Equal(card, com.GetCommanderCard());
        }

        [Fact]
        public void TryToGetCommanderCard_WithNoCard_ShouldReturnEmptyDTO()
        {
            MtGCommander com = new();
            var c = com.GetCommanderCard();
            Assert.Equal(default(MtGCardRecordDTO), c);
        }

        [Fact]
        public void SetCommanderDeathCounterToOne_CheckIfCountIsSame_ShouldReturnOne()
        {
            MtGCommander com = new();
            com.CommanderDied();
            Assert.Equal(1,com.GetDiedAmount());
        }

        [Fact]
        public void SetCommanderDeathCounterToOneResetCounter_CheckIfCountIsZero_ShouldReturnZero()
        {
            MtGCommander com = new();
            com.CommanderDied();
            com.ResetDiedCounter();
            Assert.Equal(0, com.GetDiedAmount());
        }

        [Fact]
        public void GetCommanderDeathCount_WhenCommanderHasntDiedOnce_ShouldReturnZero()
        {
            MtGCommander com = new();
            Assert.Equal(0, com.GetDiedAmount());
        }
    }
}
