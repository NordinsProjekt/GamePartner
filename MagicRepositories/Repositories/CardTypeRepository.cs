using MtGCard_Service.Interface;
using MtGDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicRepositories.Repositories;

public class CardTypeRepository : ICardTypeRepository
{
    private readonly PortalContext _context;

    public CardTypeRepository(PortalContext context)
    {
        _context = context;
    }

    public CardType FindOrCreateCardType(string typeName)
    {
        var type = _context.CardType.FirstOrDefault(ct => ct.Name == typeName);
        if (type == null)
        {
            type = new CardType { Id = Guid.NewGuid(), Name = typeName };
            _context.CardType.Add(type);
            _context.SaveChanges();  // Synchronous save, consider async in a real-world application
        }
        return type;
    }

    // Other CRUD operations can be added here
}
