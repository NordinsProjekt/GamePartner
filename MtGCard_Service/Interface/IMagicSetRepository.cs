using MtGDomain.Entities;

namespace MtGCard_Service.Interface
{
    public interface IMagicSetRepository
    {
        Task<MagicSet> FindOrCreateSet(string setName, string setCode);
    }
}