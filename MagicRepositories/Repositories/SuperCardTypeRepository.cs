using Microsoft.EntityFrameworkCore;
using MtGCard_Service.Interface;
using MtGDomain.Entities;

namespace MagicRepositories.Repositories;

public class SuperCardTypeRepository : ISuperCardTypeRepository
{
    private readonly PortalContext _context;

    public SuperCardTypeRepository(PortalContext context)
    {
        _context = context;
    }

    public async Task<MagicCardSuperCardType> FindOrCreateSuperCardType(string typeName, Guid cardId)
    {
        try
        {

            var type = _context.SuperCardTypes.FirstOrDefault(ct => ct.Name == typeName);
            if (type == null)
            {
                type = new SuperCardType { Id = Guid.NewGuid(), Name = typeName };
                _context.SuperCardTypes.Add(type);
                await _context.SaveChangesAsync();
            }

            return new() { SuperCardTypeId = type.Id, MagicCardId = cardId };
        
        }
        catch (Exception ex)
        {

            throw;
        }

    }
}
