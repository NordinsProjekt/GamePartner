using MtGDomain.Entities;

namespace MtGCard_Service.Interface;

public interface ICardSubTypeRepository
{
    Task<CardSubTypeMagicCard> CreateCardSubType(string typeName, Guid cardId);
    Task<List<CardSubType>> GetAll();
}