using Domain.MtGDomain.DTO;
using MtGCard_API;
using MtGCard_Service.Interface;
using MtGDomain.Models;
using NSubstitute;

namespace UnitTestForSolution._0._2_Infrastructure
{
    [Trait("Infrastructure", "SearchForCards")]
    public class SearchForCard_Test
    {
        private IMtGCardRepository GetRepository()
        {
            return new MockData();
        }

        [Fact]
        public void TryingOutSubstitute_CallingGetCardsByName_ShouldReceive1Call()
        {
            var api = Substitute.For<IMtGCardRepository>();
            api.GetCardsByName("Glissa");
            api.Received(1).GetCardsByName("Glissa");
        }

        [Fact]
        public void TryingOutSubstitute_CallingGetCardsByName_ShouldReturnAListOfCards()
        {
            var api = Substitute.For<IMtGCardRepository>();
            api.GetCardsByName("").ReturnsForAnyArgs(new List<MtGCardRecordDTO>());
            var result = api.GetCardsByName("").Result;
            Assert.True(result.Count == 0);
        }

        [Fact]
        public void TryingOutSubstitute_CallingGetCardsByName_ShouldReturnAListOfCardsWithCount1()
        {
            var api = Substitute.For<IMtGCardRepository>();
            api.GetCardsByName("").ReturnsForAnyArgs(new List<MtGCardRecordDTO>()
            { new MtGCardObject() { Name = "Glissa"}.GetDTO() });
            var result = api.GetCardsByName("Gli").Result;
            Assert.True(result.Count == 1);
        }
        [Fact]
        public async Task Call_()
        {
            var repo = GetRepository();

            var list = await repo.GetCardsByName("Bad Moon");

            Assert.NotNull(list);
            Assert.True(list.Count == 1);
        }

        [Fact]
        public async Task Call_GetRandomCardsFromApi_ShouldReturnAListWithCount_OverZero()
        {
            var repo = GetRepository();

            var list = await repo.GetRandomCardsFromApi("TDK");

            Assert.True(list.Count > 0);
        }

        [Fact]
        public async Task Call_GetAllSets_ShouldReturnAListWithCount_OverZero()
        {
            var repo = GetRepository();

            var list = await repo.GetAllSets();

            Assert.True(list.Count > 0);

        }
    }
}
