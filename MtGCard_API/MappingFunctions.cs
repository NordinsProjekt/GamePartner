using Mapster;
using Application.MtGCard_Service.DTO;
using MtgApiManager.Lib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
