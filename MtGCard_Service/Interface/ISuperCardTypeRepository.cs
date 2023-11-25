using MtGDomain.Entities;

namespace MtGCard_Service.Interface
{
    public interface ISuperCardTypeRepository
    {
        Task<MagicCardSuperCardType> FindOrCreateSuperCardType(string typeName, Guid cardId);
    }
}