using Domain.MtGDomain.DTO;

namespace Application.MtGCard_Service.Interface
{
    public interface IMtGCardRepository
    {
        Task<List<MtGCardRecordDTO>> GetCardsByName(string name);
        Task<List<MtGCardRecordDTO>> GetRandomCardsFromApi(string setCode);
        Task<List<MtGSetRecordDTO>> GetAllSets();
        Task<List<MtGCardRecordDTO>> GetBoosterPackFromSet(string setcode);
    }
}
