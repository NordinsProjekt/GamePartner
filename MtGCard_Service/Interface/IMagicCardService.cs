using Domain.MtGDomain.DTO;
using MtGDomain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_Service.Interface;

public interface IMagicCardService
{
    Task<bool> SaveCardsFromSet(string setCode);
    Task<MtGCardSet> GetSetBySetCode(string setCode);
    Task<List<MtGSetRecordDTO>> GetSetList();
}