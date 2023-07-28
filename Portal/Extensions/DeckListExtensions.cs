using Domain.MtGDomain.DTO;
using Infrastructure.MtGCard_API;
using MtGDomain.DTO;
using MtGDomain.Enums;
using MtGDomain.Extensions;

namespace Portal.Extensions
{
    public static class DeckListExtensions
    {
        public static List<MtGDeckCard> AddCardToDeck(this List<MtGDeckCard> list, MtGCardRecordDTO currentCard, int amount, CardLocation location)
        {
            var deckCard = list.FirstOrDefault(x => x.Card.Name.Equals(currentCard.Name));

            if (deckCard is null)
            {
                list.Add(GenerateNewMtGDeckCard(currentCard, amount, location));
                return list;
            }

            var newDeckCard = EditNewMtGDeckCard(deckCard,amount, location);
            list.Remove(deckCard);
            list.Add(newDeckCard);

            return list;
        }

        private static MtGDeckCard GenerateNewMtGDeckCard(MtGCardRecordDTO currentCard, int amount, CardLocation location)
        {
            int newAmount = amount;

            if (amount > 4)
                newAmount = 4;

            if (amount < 1)
                newAmount = 1;

            if (currentCard.FindSuperType("Basic"))
                newAmount = amount;

            return new MtGDeckCard()
            {
                Amount = newAmount,
                Card = MappingFunctions.CloneMtGRecord(currentCard),
                Location = location
            };
        }

        private static MtGDeckCard EditNewMtGDeckCard(MtGDeckCard currentDeckCard, int amount, CardLocation location)
        {
            int newAmount = currentDeckCard.Amount + amount;
            if (currentDeckCard.Card.FindSuperType("Basic"))
            {
                return new MtGDeckCard()
                {
                    Amount = newAmount,
                    Card = MappingFunctions.CloneMtGRecord(currentDeckCard.Card),
                    Location = location
                };
            }

            if (newAmount > 4)
                newAmount = 4;

            if (newAmount < 1)
                newAmount = 1;

            return new MtGDeckCard()
            {
                Amount = newAmount,
                Card = MappingFunctions.CloneMtGRecord(currentDeckCard.Card),
                Location = location
            };
        }
        
    }
}
