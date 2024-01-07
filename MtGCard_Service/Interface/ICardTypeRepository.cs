using MtGDomain.Entities;

namespace MtGCard_Service.Interface
{
    public interface ICardTypeRepository
    {
        Task<CardTypeMagicCard> CreateCardType(string typeName, Guid cardId);
        Task<List<CardType>> GetAll();
    }
}