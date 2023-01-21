using Mapster;
using Application.MtGCard_Service.DTO;
using MtgApiManager.Lib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.MtGDomain.DTO;

namespace Infrastructure.MtGCard_API
{
    public static class MappingFunctions
    {
        public static MtGCardRecordDTO MapICardToNewDto(ICard card)
        {
            var cardDto = card.Adapt<MtGCardRecordDTO>();
            return cardDto;
        }
    }
}
