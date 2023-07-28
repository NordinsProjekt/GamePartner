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
    }
}
