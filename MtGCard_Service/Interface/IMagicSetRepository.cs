using MtGDomain.Entities;

namespace MtGCard_Service.Interface
{
    public interface IMagicSetRepository
    {
        Task<Guid> FindOrCreateSet(string setName, string setCode);
        Task<bool> FindSetBySetCode(string setCode);
        Task<MagicSet> GetSetByCode(string setCode);
        Task<List<MagicSet>> GetAll();
    }
}