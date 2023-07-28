using Mapster;
using MtgApiManager.Lib.Model;
using Domain.MtGDomain.DTO;
using MtGDomain.Models;

namespace Infrastructure.MtGCard_API
{
    public static class MappingFunctions
    {
        public static MtGCardRecordDTO MapICardToNewDto(ICard card)
            => card.Adapt<MtGCardRecordDTO>();
        public static MtGCardObject MapICardToMtGCardObject(ICard card)
            => card.Adapt<MtGCardObject>();
        public static MtGCardRecordDTO CloneMtGRecord(MtGCardRecordDTO record)
            => record.Adapt<MtGCardRecordDTO>();
    }
}
