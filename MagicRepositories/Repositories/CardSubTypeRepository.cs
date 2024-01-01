using Microsoft.EntityFrameworkCore;
using MtGCard_Service.Interface;
using MtGDomain.Entities;

namespace MagicRepositories.Repositories;

public class CardSubTypeRepository : ICardSubTypeRepository
{
    private readonly PortalContext _context;

    public CardSubTypeRepository(PortalContext context)
    {
        _context = context;
    }

    public async Task<CardSubTypeMagicCard> CreateCardSubType(string typeName, Guid cardId)
    {
        var type = new CardSubType
        {
            Id = Guid.NewGuid(),
            Name = typeName
        };

        _context.CardSubType.Add(type);
        await _context.SaveChangesAsync();

        _context.Logs.Add(new Log()
        {
            CreatedUTC = DateTime.UtcNow,
            Id = Guid.NewGuid(),
            Message = $"Adding CardSubType {typeName}",
            Section = "Magic"
        });
        return new() { CardSubTypeId = type.Id, MagicCardId = cardId };
    }

    public async Task<List<CardSubType>> GetAll()
    {
        return await _context.CardSubType.AsNoTracking().ToListAsync();
    }
}