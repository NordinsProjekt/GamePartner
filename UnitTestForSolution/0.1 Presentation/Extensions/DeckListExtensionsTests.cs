using MtGDomain.DTO;
using MtGDomain.Models;
using Portal.Extensions;

namespace UnitTestForSolution._0._1_Presentation.Extensions
{
    [Trait("Presentation", "DeckListExtensions")]
    public class DeckListExtensionsTests
    {
        [Fact]
        public void AddCardToDeck_AddCardToDeck_ShouldAddCardToList()
        {
            List<MtGDeckCard> list = new List<MtGDeckCard>();
            var card = new MtGCardObject() { Name = "TestCard1" }.GetDTO();

            list.AddCardToDeck(card, 1);

            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void AddCardToDeck_AddCardToDeck_CardAlreadyExistWithAmount_One_CardInListShouldHaveAmount_Two()
        {
            Guid id = Guid.NewGuid();
            List<MtGDeckCard> list = new List<MtGDeckCard>()
            {
                new(){ Amount = 1, Card = new MtGCardObject() { Id = id.ToString(), Name = "TestCard1",  }.GetDTO() }
            };

            var card = new MtGCardObject() { Id = id.ToString(), Name = "TestCard1" }.GetDTO();

            list.AddCardToDeck(card, 1);
            var result = list.First(x=>x.Card.Id.Equals(id.ToString()));

            Assert.Equal(1, list.Count);
            Assert.Equal(2, result.Amount);
        }

        [Fact]
        public void AddCardToDeck_MaximumCardAllowedShouldBeFour_IfNotBasicLands_ShouldEqualToFour()
        {
            Guid id = Guid.NewGuid();
            List<MtGDeckCard> list = new List<MtGDeckCard>()
            {
                new(){ Amount = 2, Card = new MtGCardObject() { Id = id.ToString(), Name = "TestCard1",  }.GetDTO() }
            };
            var card = new MtGCardObject() { Id = id.ToString(), Name = "TestCard1" }.GetDTO();

            list.AddCardToDeck(card, 3);
            var result = list.First(x => x.Card.Id.Equals(id.ToString()));

            Assert.Equal(1, list.Count);
            Assert.Equal(4, result.Amount);
        }

        [Fact]
        public void AddCardToDeck_AddingCardsMultipleTimes_IfNotBasicLands_ShouldEqualToFour()
        {
            Guid id = Guid.NewGuid();
            List<MtGDeckCard> list = new List<MtGDeckCard>()
            {
                new(){ Amount = 2, Card = new MtGCardObject() { Id = id.ToString(), Name = "TestCard1",  }.GetDTO() }
            };
            var card = new MtGCardObject() { Id = id.ToString(), Name = "TestCard1" }.GetDTO();

            list.AddCardToDeck(card, 1);
            list.AddCardToDeck(card, 1);
            list.AddCardToDeck(card, 1);
            var result = list.First(x => x.Card.Id.Equals(id.ToString()));

            Assert.Equal(1, list.Count);
            Assert.Equal(4, result.Amount);
        }

        [Fact]
        public void AddCardToDeck_AddingCardsToDeck_IfBasicLands_ShouldEqualTo24()
        {
            Guid id = Guid.NewGuid();
            List<MtGDeckCard> list = new List<MtGDeckCard>()
            {
                new(){ Amount = 2, Card = new MtGCardObject() { Id = id.ToString(), Name = "TestCard1",SuperTypes = new string[] { "Basic" }  }.GetDTO() }
            };
            var card = new MtGCardObject() { Id = id.ToString(), Name = "TestCard1", 
                SuperTypes = new string[] { "Basic" } }.GetDTO();

            list.AddCardToDeck(card, 22);
            var result = list.First(x => x.Card.Id.Equals(id.ToString()));

            Assert.Equal(1, list.Count);
            Assert.Equal(24, result.Amount);
        }

        [Fact]
        public void AddCardToDeck_AddingCardToEmptyDeckList_IfBasicLands_ShouldEqualTo24()
        {
            Guid id = Guid.NewGuid();
            List<MtGDeckCard> list = new List<MtGDeckCard>();

            var card = new MtGCardObject()
            {
                Id = id.ToString(),
                Name = "TestCard1",
                SuperTypes = new string[] { "Basic" }
            }.GetDTO();

            list.AddCardToDeck(card, 24);
            var result = list.First(x => x.Card.Id.Equals(id.ToString()));

            Assert.Equal(1, list.Count);
            Assert.Equal(24, result.Amount);
        }

        [Fact]
        public void AddCardToDeck_AddingCardToEmptyDeckList_ShouldEqualTo1()
        {
            Guid id = Guid.NewGuid();
            List<MtGDeckCard> list = new List<MtGDeckCard>();

            var card = new MtGCardObject()
            {
                Id = id.ToString(),
                Name = "TestCard1",
            }.GetDTO();

            list.AddCardToDeck(card, 1);
            var result = list.First(x => x.Card.Id.Equals(id.ToString()));

            Assert.Equal(1, list.Count);
            Assert.Equal(1, result.Amount);
        }

        [Fact]
        public void AddCardToDeck_AddingCardToEmptyDeckList_ShouldEqualTo2()
        {
            Guid id = Guid.NewGuid();
            List<MtGDeckCard> list = new List<MtGDeckCard>();

            var card = new MtGCardObject()
            {
                Id = id.ToString(),
                Name = "TestCard1",
            }.GetDTO();

            list.AddCardToDeck(card, 2);
            var result = list.First(x => x.Card.Id.Equals(id.ToString()));

            Assert.Equal(1, list.Count);
            Assert.Equal(2, result.Amount);
        }

        [Fact]
        public void AddCardToDeck_AddingCardToEmptyDeckList_ShouldEqualTo3()
        {
            Guid id = Guid.NewGuid();
            List<MtGDeckCard> list = new List<MtGDeckCard>();

            var card = new MtGCardObject()
            {
                Id = id.ToString(),
                Name = "TestCard1",
            }.GetDTO();

            list.AddCardToDeck(card, 3);
            var result = list.First(x => x.Card.Id.Equals(id.ToString()));

            Assert.Equal(1, list.Count);
            Assert.Equal(3, result.Amount);
        }
    }
}
