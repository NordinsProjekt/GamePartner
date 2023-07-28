using Domain.MtGDomain.DTO;
using Infrastructure.MtGCard_API;
using MtGDomain.DTO;
using MtGDomain.Extensions;

namespace Portal.Extensions
{
    public static class DeckListExtensions
    {
        public static List<MtGDeckCard> AddCardToDeck(this List<MtGDeckCard> list, MtGCardRecordDTO currentCard, int amount)
        {
            //Fix later
            var deckCard = list.FirstOrDefault(x => x.Card.Id.Equals(currentCard.Id));
            int newAmount = amount;

            if (!currentCard.FindSuperType("Basic"))
            {
                if (amount > 4) { newAmount = 4; }
            }

            if (deckCard is null)
            {
                list.Add(new MtGDeckCard()
                {
                    Amount = newAmount,
                    Card = MappingFunctions.CloneMtGRecord(currentCard)
                });
                return list;
            }

            if (!currentCard.FindSuperType("Basic"))
            {
                newAmount += deckCard.Amount;
                if (newAmount > 4) { newAmount = 4; }
            }
            else 
            {
                newAmount += deckCard.Amount; 
            }

            var newEntry = new MtGDeckCard()
            { Amount = newAmount, Card = MappingFunctions.CloneMtGRecord(currentCard) };
            list.Remove(deckCard);
            list.Add(newEntry);

            return list;
        }
    }
}
