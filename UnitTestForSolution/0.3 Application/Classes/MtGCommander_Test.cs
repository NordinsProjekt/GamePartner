using Domain.MtGDomain.DTO;
using FluentAssertions;
using MtGCard_Service.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestForSolution._0._3_Application.Classes
{
    [Trait("Application", "MtGCommander Class")]
    public class MtGCommander_Test
    {
        [Fact]
        public void TryToSetCommanderCard_WithAnAcceptedCard_ShouldReturnTheCard()
        {
            MtGCardRecordDTO card = new("Testcard", "1", "Testcard", new(), new(), "www.", "11", new string[] { "Creature" }, new string[] { "Legendary" }, 0);
            MtGCommander com = new();
            com.SetCommanderCard(card);
            Assert.Equal(card, com.GetCommanderCard());
        }

        [Fact]
        public void TryToGetCommanderCard_WithNoCard_ShouldReturnEmptyDTO()
        {
            MtGCommander com = new();
            var c = com.GetCommanderCard();
            c.Should().BeNull();
        }

        [Fact]
        public void SetCommanderDeathCounterToOne_CheckIfCountIsSame_ShouldReturnOne()
        {
            MtGCommander com = new();
            com.CommanderDied();
            Assert.Equal(1, com.GetDiedAmount());
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
