using Application.MtGCard_Service.DTO;
using Domain.MtGDomain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MtGCard_Service.DTO
{
    public sealed record MtGSearchResultRecord_DTO(string SearchText, List<MtGCardRecordDTO> SearchResult);
}
