using MtGCard_Service.Classes;
using MtGCard_Service.Classes.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestForSolution._0._3_Application.Classes
{
    [Trait("Application", "MtGPlayer class")]
    public class MtGPlayer_Test
    {
        [Fact]
        public void DoOnePoisonDamageToPlayer_ShouldReceiveOnePoisonDamage()
        {
            MtGPlayer player = new(1, "Player 1", 4);
            player.TakePoisonDamage(1);
            Assert.True(player.GetPlayerPoisonCount == 1);
        }

        [Fact]
        public void DoFiveRegularDamageToPlayer_ShouldHave35LifeLeft()
        {
            MtGPlayer player = new(1, "Player 1", 4);
            player.DoDamage(5);
            Assert.True(player.LifeTotal == 35);
        }

        [Fact]
        public void MakePlayerWithId1_CallGetPlayerId_ShouldBe1()
        {
            MtGPlayer player = new(1, "Player 1", 4);
            Assert.True(player.GetPlayerId == 1);
        }

        [Fact]
        public void MakePlayerWithId1_CallGetPlayerId_ShouldNotBe0()
        {
            MtGPlayer player = new(1, "Player 1", 4);
            Assert.False(player.GetPlayerId == 0);
        }

        [Fact]
        public void MakePlayerWithId1_CallGetPlayerId_ShouldNotBe2()
        {
            MtGPlayer player = new(1, "Player 1", 4);
            Assert.False(player.GetPlayerId == 2);
        }

        [Fact]
        public void MakePlayerWithNamePlayer1_CallGetPlayerName_ShouldReturnPlayer1()
        {
            MtGPlayer player = new(1, "Player1", 4);
            Assert.True(player.GetPlayerName == "Player1");
        }
    }
}
