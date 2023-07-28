using Domain.MtGDomain.DTO;

namespace MtGDomain.DTO
{
    public class MtGDeckCard
    {
        public int Amount { get; set; }
        public MtGCardRecordDTO Card { get; set; }

        public bool IsBasicLand()
        {
            if (Card is not null && Card.SuperTypes.Contains("Basic"))
                return true;
            return false;
        }
    }
}
