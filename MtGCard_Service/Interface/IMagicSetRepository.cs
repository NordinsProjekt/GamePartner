using MtGDomain.Entities;

namespace MtGCard_Service.Interface
{
    public interface IMagicSetRepository
    {
        Task<Guid> FindOrCreateSet(string setName, string setCode);
    }
}