using MtGDomain.Entities;

namespace MtGCard_Service.Interface;

public interface ISuperCardTypeRepository
{
    Task<MagicCardSuperCardType> CreateSuperCardType(string typeName, Guid cardId);
    Task<List<SuperCardType>> GetAll();
}