using Domain.MtGDomain.DTO;
using MtGCard_API;
using MtGCard_Service;
using MtGCard_Service.Classes.Extensions;
using MtGCard_Service.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace UnitTestForSolution._0._3_Application
{
    [Trait("Application", "CommanderService Everything")]
    public class MtGCommanderService_Test
    {
        private MtGCardRecordDTO GetTestCard()
            => new MtGCardRecordDTO("TestCard", "1", "This is a testcard", null, null, "https://www.img.com", "FR54", null, null, 0, false, false, "{1}{B}", "", "");
        [Fact]
        public void AddingACardToPlayerCardList_Player2WillGetTheCard_TheListShouldHaveCount1()
        {
            MockData _rep = new MockData();
            MtGCommanderService mcs = new MtGCommanderService(_rep, 4);
            MtGCardRecordDTO card = GetTestCard();
            mcs.AddCardToPlayer(1, card);
            Assert.True(mcs.GetPlayerCardList(1).Count() == 1);
        }

        [Fact]
        public void AddingTwoCardToPlayerCardList_Player2WillGetTheCardRemoveOneCard_TheListShouldHaveCount1()
        {
            MockData _rep = new MockData();
            MtGCommanderService mcs = new MtGCommanderService(_rep, 4);
            MtGCardRecordDTO card = GetTestCard(); 
            mcs.AddCardToPlayer(1, card);
            mcs.AddCardToPlayer(1, card);
            mcs.RemoveCardFromPlayer(1, card.Id);
            Assert.True(mcs.GetPlayerCardList(1).Count() == 1);
        }

        [Fact]
        public void AddingTwoCardToPlayerCardList_Player2WillGetTheCardRemoveTwoCards_TheListShouldHaveCount0()
        {
            MockData _rep = new MockData();
            MtGCommanderService mcs = new MtGCommanderService(_rep, 4);
            MtGCardRecordDTO card = GetTestCard();
            mcs.AddCardToPlayer(1, card);
            mcs.RemoveCardFromPlayer(1, card.Id);
            mcs.AddCardToPlayer(1, card);
            mcs.RemoveCardFromPlayer(1, card.Id);
            Assert.True(mcs.GetPlayerCardList(1).Count() == 0);
        }

        [Fact]
        public void AddingTwoCardToPlayerCardList_Player2WillGetTheCardRemoveThreeCards_TheListShouldHaveCount0()
        {
            MockData _rep = new MockData();
            MtGCommanderService mcs = new MtGCommanderService(_rep, 4);
            MtGCardRecordDTO card = GetTestCard();
            mcs.RemoveCardFromPlayer(1, card.Id);
            mcs.AddCardToPlayer(1, card);
            mcs.RemoveCardFromPlayer(1, card.Id);
            mcs.RemoveCardFromPlayer(1, card.Id);
            Assert.True(mcs.GetPlayerCardList(1).Count() == 0);
        }

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
            Assert.True(mcs.GetPlayerCommanderDamageFromSpecifikPlayer(0, 1) == 10);
        }

        [Fact]
        [Trait("Commander Heal", "PlayerLife Changes")]
        public void CreateCommanderObjectWith4Players_Take10CommanderDamageFromPlayer2AsPlayer1AndThenHeal10Dmg_ShouldReturn0CommanderDamageFromPlayer2()
        {
            MockData _rep = new MockData();
            MtGCommanderService mcs = new MtGCommanderService(_rep, 4);
            mcs.PlayerTakesCommanderDamage(0, 1, 10);
            mcs.PlayerHealsCommanderDamage(0, 1, 10);
            Assert.True(mcs.GetPlayerCommanderDamageFromSpecifikPlayer(0, 1) == 0);
        }

        [Fact]
        [Trait("SearchList", "MTG API (Mock Data)")]
        public async Task GetCardsFromDataSource_VerifyThatSearchListIsNotEmpty_ShouldNotReturn0()
        {
            MockData _rep = new MockData();
            MtGCommanderService mcs = new MtGCommanderService(_rep, 4);
            await mcs.SearchForCard("Delver");
            Assert.False(mcs.SearchResultCount == 0);
        }

        [Fact]
        [Trait("SearchList", "MTG API (Mock Data)")]
        public async Task GetCardsFromDataSource_VerifyThatImageUrlIsntEmpty_ShouldNotBeNull()
        {
            MockData _rep = new MockData();
            MtGCommanderService mcs = new MtGCommanderService(_rep, 4);
            await mcs.SearchForCard("Blood");
            var cards = mcs.GetSearchResult();
            Assert.True(cards.Count > 0);
            foreach (var card in cards)
            {
                Assert.False(card.ImageUrl == "");
            }

        }
        [Fact]
        [Trait("SearchBuffer", "MTG API (Mock Data)")]
        public async Task SearchingForACard_CheckIfSearchBufferWillBeUsed_ShouldOnlyReturnTheDataInBuffer()
        {
            MockData _rep = new MockData();
            SearchBuffer _buffer = new SearchBuffer();
            _buffer.AddToSearchBuffer("Test", new List<MtGCardRecordDTO>() { GetTestCard() });
            MtGCommanderService mcs = new MtGCommanderService(_rep, _buffer);
            await mcs.SearchForCard("Test");
            var cards = mcs.GetSearchResult();
            Assert.True(cards[0].Name == "TestCard");
        }

        [Fact]
        [Trait("SearchBuffer", "MTG API (Mock Data)")]
        public async Task SearchingForACard_WillSearchForCardThatDoesntExist_ShouldReturnAnEmptyList()
        {
            MockData _rep = new MockData();
            SearchBuffer _buffer = new SearchBuffer();
            _buffer.AddToSearchBuffer("Test", new List<MtGCardRecordDTO>() { GetTestCard() });
            MtGCommanderService mcs = new MtGCommanderService(_rep, _buffer);
            mcs.CreateNumPlayers(4);
            await mcs.SearchForCard("Test34");
            var cards = mcs.GetSearchResult();
            Assert.True(cards.Count() == 0);
        }

        [Fact]
        public void CreateCommanderObjectWith4Players_ShouldReturnPlayerListCount4()
        {
            MockData _rep = new MockData();
            MtGCommanderService mcs = new MtGCommanderService(_rep, 4);
            Assert.True(mcs.PlayerCount == 4);
        }
        [Fact]
        public void CreateCommanderObjectWith4Players_CheckIfAllPlayersStartWith40Life_ShouldReturn40ForAllPlayers()
        {
            MockData _rep = new MockData();
            MtGCommanderService mcs = new MtGCommanderService(_rep, 4);
            for (int i = 0; i < 4; i++)
                Assert.True(mcs.GetPlayerLifeTotal(i) == 40);
        }
        [Fact]
        public void CreateCommanderObjectWith4Players_CheckIfAllPlayersStartWith0PoisonCounters_ShouldReturn0ForAllPlayers()
        {
            MockData _rep = new MockData();
            MtGCommanderService mcs = new MtGCommanderService(_rep, 4);
            for (int i = 0; i < 4; i++)
                Assert.True(mcs.GetPlayerPoisonCountTotal(i) == 0);
        }
    }

}
