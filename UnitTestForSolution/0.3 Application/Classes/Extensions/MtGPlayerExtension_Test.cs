using MtGCard_Service.Classes;
using MtGCard_Service.Classes.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestForSolution._0._3_Application.Classes.Extensions
{
    [Trait("Application", "MtGPlayer Extensions")]
    public class MtGPlayerExtension_Test
    {
        private MtGPlayer player = new(1, "Player 1", 4);

        [Fact]
        public void CreateNewPlayer_DoFiveDamage_PlayerLifeShouldBe35()
        {
            player.DoDamage(5);
            Assert.True(player.LifeTotal == 35);
        }

        [Fact]
        public void CreateNewPlayer_HealFive_PlayerLifeShouldBe45()
        {
            player.Heal(5);
            Assert.True(player.LifeTotal == 45);
        }

        [Fact]
        public void CreateNewPlayer_Do5Damage_Heal5_ShouldHaveLifeTotalOf40()
        {
            player.DoDamage(5);
            player.Heal(5);
            Assert.True(player.LifeTotal == 40);
        }
    }
}
