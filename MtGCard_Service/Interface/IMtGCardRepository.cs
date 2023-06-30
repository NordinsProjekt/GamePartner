using Domain.MtGDomain.DTO;

namespace Application.MtGCard_Service.Interface
{
    public interface IMtGCardRepository
    {
        Task<List<MtGCardRecordDTO>> GetCardsByName(string name);
        Task<List<MtGCardRecordDTO>> GetRandomCardsFromApi(string setname);
        Task<List<MtGSetRecordDTO>> GetAllSets();
    }
}
