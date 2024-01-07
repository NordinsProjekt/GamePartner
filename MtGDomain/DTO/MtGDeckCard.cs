using Domain.MtGDomain.DTO;
using MtGDomain.Enums;

namespace MtGDomain.DTO
{
    public class MtGDeckCard
    {
        public int Amount { get; set; }
        public CardLocation Location { get; set; }
        public MtGCardRecordDTO? Card { get; set; }

        public bool IsBasicLand()
        {
            if (Card is not null && Card.SuperTypes.Contains("Basic"))
                return true;
            return false;
        }
    }
}
