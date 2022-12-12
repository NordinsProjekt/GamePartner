using Application.MtGCard_Service.DTO;
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
    public class Test_CommanderService_SearchResult
    {
        private readonly ITestOutputHelper _testOutputHelper;
        public Test_CommanderService_SearchResult(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
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
            _buffer.AddToSearchBuffer("Test", new List<MtGCardRecordDTO>() { new MtGCardRecordDTO("TestCard", "1", "TestCard", null, "image url", "fop3jdf32") });
            MtGCommanderService mcs = new MtGCommanderService(_rep,_buffer);
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
            _buffer.AddToSearchBuffer("Test", new List<MtGCardRecordDTO>() { new MtGCardRecordDTO("TestCard", "1", "TestCard", null, "image url", "fop3jdf32") });
            MtGCommanderService mcs = new MtGCommanderService(_rep, _buffer);
            mcs.CreateNumPlayers(4);
            await mcs.SearchForCard("Test34");
            var cards = mcs.GetSearchResult();
            Assert.True(cards.Count() == 0);
        }
    }
}
