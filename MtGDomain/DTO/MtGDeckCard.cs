using Domain.MtGDomain.DTO;

namespace MtGDomain.DTO
{
    public class MtGDeckCard
    {
        public int Amount { get; set; }
        public MtGCardRecordDTO Card { get; set; }
    }
}
