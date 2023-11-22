using MtGCard_Service.Interface;
using MtGDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicRepositories.Repositories;

public class SuperCardTypeRepository : ISuperCardTypeRepository
{
    private readonly PortalContext _context;

    public SuperCardTypeRepository(PortalContext context)
    {
        _context = context;
    }

    public SuperCardType FindOrCreateSuperCardType(string typeName)
    {
        var type = _context.SuperCardTypes.FirstOrDefault(ct => ct.Name == typeName);
        if (type == null)
        {
            type = new SuperCardType { Id = Guid.NewGuid(), Name = typeName };
            _context.SuperCardTypes.Add(type);
            _context.SaveChanges();  // Synchronous save, consider async in a real-world application
        }
        return type;
    }

    // Other CRUD operations can be added here
}
