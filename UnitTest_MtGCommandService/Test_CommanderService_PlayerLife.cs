using Infrastructure.MtGCard_API;
using MtGCard_API;
using MtGCard_Service;
using MtGCard_Service.Classes.Extensions;
using MtGCard_Service.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_MtGCommanderService
{
    
    public class Test_CommanderService_PlayerLife
    {
        [Fact]
        [Trait("Damage", "PlayerLife Changes")]
        public void CreateCommanderObjectWith4Players_Do5DamageToPlayer2_ShouldReturnLife35ForPlayer2()
        {
            MockData _rep = new MockData();
            MtGCommanderService mcs = new MtGCommanderService(_rep, 4);
            mcs.PlayerTakesDamage(1, 5);
            Assert.True(mcs.GetPlayerLifeTotal(1) == 35);
        }

        [Fact]
        [Trait("Damage", "PlayerLife Changes")]
        public void CreateCommanderObjectWith4Players_Do5PoisonDamageToPlayer2_ShouldReturnPoisonCounterTotal5()
        {
            MockData _rep = new MockData();
            MtGCommanderService mcs = new MtGCommanderService(_rep, 4);
            mcs.PlayerTakesPoisonDamage(1, 5);
            Assert.True(mcs.GetPlayerPoisonCountTotal(1) == 5);
        }
        [Fact]
        [Trait("Heal", "PlayerLife Changes")]
        public void CreateCommanderObjectWith4Players_LifeGain5ForPlayer3_ShouldReturnPlayerLifeTotalOf45_ForPlayer3()
        {
            MockData _rep = new MockData();
            MtGCommanderService mcs = new MtGCommanderService(_rep, 4);
            mcs.GetPlayer(2).Heal(5);
            Assert.True(mcs.GetPlayer(2).LifeTotal == 45);
        }

        [Fact]
        [Trait("Heal", "PlayerLife Changes")]
        public void CreateCommanderObjectWith4Players_Take6DamageLifeGain5ForPlayer3_ShouldReturnPlayerLifeTotalOf39_ForPlayer3()
        {
            MockData _rep = new MockData();
            MtGCommanderService mcs = new MtGCommanderService(_rep, 4);
            mcs.PlayerTakesDamage(2, 6);
            mcs.PlayerGainLife(2, 5);
            Assert.True(mcs.GetPlayerLifeTotal(2) == 39);
        }

        [Fact]
        [Trait("RemovePoison", "PlayerLife Changes")]
        public void CreateCommanderObjectWith4Players_Give5PoisonDamageAndThenRemove5PoisonDamage_ShouldReturnPlayerPoisonCountTotal0_ForPlayer3()
        {
            MockData _rep = new MockData();
            MtGCommanderService mcs = new MtGCommanderService(_rep, 4);
            mcs.PlayerTakesPoisonDamage(2, 5);
            mcs.PlayerHealsPoisonDamage(2, 5);
            Assert.True(mcs.GetPlayerPoisonCountTotal(2) == 0);
        }
        [Fact]
        [Trait("RemovePoison", "PlayerLife Changes")]
        public void CreateCommanderObjectWith4Players_Give5PoisonDamageAndThenRemove6PoisonDamage_ShouldReturnPlayerPoisonCountTotal0_ForPlayer3()
        {
            MockData _rep = new MockData();
            MtGCommanderService mcs = new MtGCommanderService(_rep, 4);
            mcs.PlayerTakesPoisonDamage(2, 5);
            mcs.PlayerHealsPoisonDamage(2, 6);
            Assert.True(mcs.GetPlayerPoisonCountTotal(2) == 0);
        }
        [Fact]
        [Trait("RemovePoison", "PlayerLife Changes")]
        public void CreateCommanderObjectWith4Players_Give6PoisonDamageAndThenRemove5PoisonDamage_ShouldReturnPlayerPoisonCountTotal1_ForPlayer3()
        {
            MockData _rep = new MockData();
            MtGCommanderService mcs = new MtGCommanderService(_rep, 4);
            mcs.PlayerTakesPoisonDamage(2, 6);
            mcs.PlayerHealsPoisonDamage(2, 5);
            Assert.True(mcs.GetPlayerPoisonCountTotal(2) == 1);

        }
        [Fact]
        [Trait("Commander Damage", "PlayerLife Changes")]
        public void CreateCommanderObjectWith4Players_Take10CommanderDamageFromPlayer2AsPlayer1_ShouldReturn10CommanderDamageFromPlayer2()
        {
            MockData _rep = new MockData();
            MtGCommanderService mcs = new MtGCommanderService(_rep, 4);
            mcs.PlayerTakesCommanderDamage(0, 1, 10);
            Assert.True(mcs.GetPlayerCommanderDamageFromSpecifikPlayer(0,1) == 10);
        }

        [Fact]
        [Trait("Commander Heal", "PlayerLife Changes")]
        public void CreateCommanderObjectWith4Players_Take10CommanderDamageFromPlayer2AsPlayer1AndThenHeal10Dmg_ShouldReturn0CommanderDamageFromPlayer2()
        {
            MockData _rep = new MockData();
            MtGCommanderService mcs = new MtGCommanderService(_rep, 4);
            mcs.PlayerTakesCommanderDamage(0, 1, 10);
            mcs.PlayerHealsCommanderDamage(0,1,10);
            Assert.True(mcs.GetPlayerCommanderDamageFromSpecifikPlayer(0, 1) == 0);
        }
    }
}
