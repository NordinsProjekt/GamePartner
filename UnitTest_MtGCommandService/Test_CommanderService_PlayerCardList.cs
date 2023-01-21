using Application.MtGCard_Service.DTO;
using Infrastructure.MtGCard_API;
using MtGCard_API;
using MtGCard_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace UnitTest_MtGCommanderService
{
    [Trait("Adding Cards", "Player CardList")]
    public class Test_CommanderService_PlayerCardList
    {
        private readonly ITestOutputHelper _testOutputHelper;
        public Test_CommanderService_PlayerCardList(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void AddingACardToPlayerCardList_Player2WillGetTheCard_TheListShouldHaveCount1()
        {
            MockData _rep = new MockData();
            MtGCommanderService mcs = new MtGCommanderService(_rep, 4);
            MtGCardRecordDTO card = new MtGCardRecordDTO("TestCard", "1", "This is a testcard", null, "https://www.img.com", "FR54",null,null);
            mcs.AddCardToPlayer(1, card);
            Assert.True(mcs.GetPlayerCardList(1).Count() == 1);
        }

        [Fact]
        public void AddingTwoCardToPlayerCardList_Player2WillGetTheCardRemoveOneCard_TheListShouldHaveCount1()
        {
            MockData _rep = new MockData();
            MtGCommanderService mcs = new MtGCommanderService(_rep, 4);
            MtGCardRecordDTO card = new MtGCardRecordDTO("TestCard", "1", "This is a testcard", null, "https://www.img.com", "FR54", null, null);
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
            MtGCardRecordDTO card = new MtGCardRecordDTO("TestCard", "1", "This is a testcard", null, "https://www.img.com", "FR54", null, null);
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
            MtGCardRecordDTO card = new MtGCardRecordDTO("TestCard", "1", "This is a testcard", null, "https://www.img.com", "FR54", null, null);
            mcs.AddCardToPlayer(1, card);
            mcs.RemoveCardFromPlayer(1, card.Id);
            mcs.AddCardToPlayer(1, card);
            mcs.RemoveCardFromPlayer(1, card.Id);
            mcs.RemoveCardFromPlayer(1, card.Id);
            Assert.True(mcs.GetPlayerCardList(1).Count() == 0);
        }
    }
}
