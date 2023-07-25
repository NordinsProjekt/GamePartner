using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MtGDomain.DTO
{
    public sealed record MtGCardRecordDTO(string Name,string Id,string Text, List<MtGRulingRecord_DTO> Rulings,
        List<string> Abilities,string ImageUrl, string MultiverseId, string[] Types,
        string[] SuperTypes, int Cmc, bool IsColorLess, bool IsMultiColor, string ManaCost, string SetName, string Set );
}
