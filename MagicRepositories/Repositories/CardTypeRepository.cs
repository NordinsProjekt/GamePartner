using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MtGCard_Service.Interface;
using MtGDomain.Entities;

namespace MagicRepositories.Repositories;

public class CardTypeRepository : ICardTypeRepository
{
    private readonly PortalContext _context;

    public CardTypeRepository(PortalContext context)
    {
        _context = context;
    }

    public async Task<CardTypeMagicCard> CreateCardType(string typeName, Guid cardId)
    {
        try
        {
            var type = new CardType
            {
                Id = Guid.NewGuid(),
                Name = typeName
            };
            _context.CardType.Add(type);
            await _context.SaveChangesAsync();

            _context.Logs.Add(new Log()
            {
                CreatedUTC = DateTime.UtcNow,
                Id = Guid.NewGuid(),
                Message = $"Adding CardType {typeName}",
                Section = "Magic"
            });
            return new() { CardTypeId = type.Id, MagicCardId = cardId };
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<List<CardType>> GetAll()
    {
        return await _context.CardType.AsNoTracking().ToListAsync();
    }
}