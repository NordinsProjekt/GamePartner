using Domain.MtGDomain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.DTO
{
    public sealed record MtGSearchResultRecord(List<MtGCardRecordDTO> SearchResult, string SearchText);
}
