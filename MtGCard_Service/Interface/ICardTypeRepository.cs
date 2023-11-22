using MtGDomain.Entities;

namespace MtGCard_Service.Interface
{
    public interface ICardTypeRepository
    {
        CardType FindOrCreateCardType(string typeName);
    }
}