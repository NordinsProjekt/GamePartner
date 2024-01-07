using Domain.MtGDomain.DTO;
using MtGCard_Service.DTO;
using MtGDomain.DTO;

namespace MtGCard_Service.Interface
{
    public interface IMtGCardRepository
    {
        Task<List<MtGCardRecordDTO>> GetCardsByName(string name);
        Task<List<MtGCardRecordDTO>> GetCardsByName(string name, MtGSearchFilter filter);
        Task<List<MtGCardRecordDTO>> GetAllCardsFromASet(string setCode);
        Task<List<MtGCardRecordDTO>> GetRandomCardsFromApi(string setCode);
        Task<List<MtGSetRecordDTO>> GetAllSets();
        Task<List<MtGCardRecordDTO>> GetBoosterPackFromSet(string setcode);
    }
}
