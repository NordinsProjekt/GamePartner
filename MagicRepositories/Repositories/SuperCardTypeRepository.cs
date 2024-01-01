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

    public async Task<MagicCardSuperCardType> CreateSuperCardType(string typeName, Guid cardId)
    {
        var type = new SuperCardType { Id = Guid.NewGuid(), Name = typeName };

        _context.SuperCardTypes.Add(type);
        await _context.SaveChangesAsync();

        return new() { SuperCardTypeId = type.Id, MagicCardId = cardId };
    }

    public async Task<List<SuperCardType>> GetAll()
    {
        return await _context.SuperCardTypes.AsNoTracking().ToListAsync();
    }
}