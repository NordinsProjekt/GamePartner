using Domain.MtGDomain.DTO;
using Infrastructure.MtGCard_API;
using MtGDomain.DTO;

namespace Portal.Extensions
{
    public static class DeckListExtensions
    {
        public static List<MtGDeckCard> AddCardToDeck(this List<MtGDeckCard> list, MtGCardRecordDTO currentCard, int amount)
        {
            var deckCard = list.FirstOrDefault(x => x.Card.Id.Equals(currentCard.Id));

            if (deckCard is not null)
            {
                var newEntry = new MtGDeckCard()
                { Amount = amount + deckCard.Amount, Card = MappingFunctions.CloneMtGRecord(currentCard) };
                list.Remove(deckCard);
                list.Add(newEntry);
            }
            else
            {
                list.Add(new MtGDeckCard()
                {
                    Amount = amount,
                    Card = MappingFunctions.CloneMtGRecord(currentCard)
                });
            }
            return list;
        }
    }
}
