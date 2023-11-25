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

    public async Task<CardTypeMagicCard> FindOrCreateCardType(string typeName, Guid cardId)
    {
        try
        {
                var type = _context.CardType.FirstOrDefault(ct => ct.Name == typeName);

                if (type == null)
                {
                    type = new CardType
                    {
                        Id = Guid.NewGuid(),
                        Name = typeName
                    };
                    _context.CardType.Add(type);
                    await _context.SaveChangesAsync();
                }

                return new() { CardTypeId = type.Id, MagicCardId = cardId };
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
