using MtGDomain.Entities;

namespace MtGCard_Service.Interface
{
    public interface ISuperCardTypeRepository
    {
        SuperCardType FindOrCreateSuperCardType(string typeName);
    }
}