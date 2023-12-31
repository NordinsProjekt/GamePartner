using MtGDomain.Entities;

namespace MtGCard_Service.Interface
{
    public interface ICardTypeRepository
    {
        Task<CardTypeMagicCard> FindOrCreateCardType(string typeName, Guid cardId);
    }
}