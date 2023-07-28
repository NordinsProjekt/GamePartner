using Domain.MtGDomain.DTO;
using MtGDomain.DTO;
using MtGDomain.Extensions;
using MtGDomain.Models;

namespace UnitTestForSolution._0._4_Domain.Extensions
{
    [Trait("Domain", "List Extension")]
    public class ListExtension_Tests
    {
        private List<MtGCardRecordDTO> GetCards()
        {
            List<MtGCardRecordDTO> list = new List<MtGCardRecordDTO>()
            {
                new MtGCardObject() { Name = "TestCard1", Types = new string[]{"Creature" }, ImageUrl = ".jpg", Cmc = 3, ManaCost = "{B}" }.GetDTO(),
                new MtGCardObject() { Name = "TestCard1", Types = new string[]{"Creature" }, ImageUrl = ".jpg", Cmc = 2 }.GetDTO(),
                new MtGCardObject() { Name = "TestCard1", Types = new string[]{"Creature" }, ImageUrl = ".jpg", Cmc = 1, ManaCost = "{B}" }.GetDTO(),
                new MtGCardObject() { Name = "TestCard1", Types = new string[]{"Instant" }, ImageUrl = ".jpg", Cmc = 2 }.GetDTO(),
                new MtGCardObject() { Name = "TestCard1", Types = new string[]{"Enchantment" }, ImageUrl = ".jpg", Cmc = 0 }.GetDTO(),
            };
            return list;
        }

        [Fact]
        public void ShuffleList_ShouldReturnANewListOfCards() 
        {
            var cardList = GetCards();
            var shuffledList = cardList.Shuffle();

            Assert.True(shuffledList.Count > 0);
            Assert.NotStrictEqual(cardList, shuffledList);
            Assert.NotEqual(cardList.GetHashCode(), shuffledList.GetHashCode());
        }

        [Fact]
        public void RemoveSpecificTypesFromAList_ShouldReturnNewList_ShouldReduseCountToThree()
        {
            List<MtGCardRecordDTO> cardList = new List<MtGCardRecordDTO>()
            {
                new MtGCardObject() { Types = new string[]{"Creature" }, ImageUrl = ".jpg" }.GetDTO(),
                new MtGCardObject() { Types = new string[]{"Creature" }, ImageUrl = ".jpg" }.GetDTO(),
                new MtGCardObject() { Types = new string[]{"Instant" }, ImageUrl = ".jpg" }.GetDTO(),
                new MtGCardObject() { Types = new string[]{"Enchantment" }, ImageUrl = ".jpg" }.GetDTO(),
            };
            var newList = cardList.RemoveMtGType(new string[] { "creature" });
            Assert.Equal(4, cardList.Count);
            Assert.Equal(2, newList.Count);
            Assert.NotStrictEqual(cardList, newList);
            Assert.NotEqual(cardList.GetHashCode(), newList.GetHashCode());
        }

        [Fact]
        public void FilterList_SendInListWithFilter_BlackColor_ShouldReturnListWithCountTwo()
        {
            var cardList = GetCards();
            var filter = new MtGSearchFilter() { ColorFilter = new() { Black = true } };
            var result = cardList.FilterList(filter);

            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void FilterList_SendInListWithFilter_CMCLessThan3_ShouldReturnListWithCountFour()
        {
            var cardList = GetCards();
            var filter = new MtGSearchFilter() { CmcFilter = new() { Cmc = 3, ChoosenSymbol = "<" }, ColorFilter = new() };
            var result = cardList.FilterList(filter);

            Assert.Equal(4, result.Count);
        }

        [Fact]
        public void FilterList_SendInListWithFilter_CMCMoreThan3_ShouldReturnListWithCountZero()
        {
            var cardList = GetCards();
            var filter = new MtGSearchFilter() { CmcFilter = new() { Cmc = 3, ChoosenSymbol = ">" }, ColorFilter = new() };
            var result = cardList.FilterList(filter);

            Assert.Empty(result);
        }
    }
}
