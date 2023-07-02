using Domain.MtGDomain.DTO;
using MtGDomain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_Service.Interface
{
    public interface ICardSetBuffer
    {
        List<MtGCardRecordDTO>? GetSet(string SetCode);
        bool AddSet(MtGCardSet set);
    }
}
