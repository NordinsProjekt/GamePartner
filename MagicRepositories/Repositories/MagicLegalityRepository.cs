using MtGCard_Service.Interface;
using MtGDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicRepositories.Repositories;

public class MagicLegalityRepository : IMagicLegalityRepository
{
    private readonly PortalContext _context;

    public MagicLegalityRepository(PortalContext context)
    {
        _context = context;
    }

    public MagicLegality FindOrCreateLegality(string format, string legalityName)
    {
        var legality = _context.MagicLegalities.FirstOrDefault(l => l.Format == format && l.LegalityName == legalityName);
        if (legality == null)
        {
            legality = new MagicLegality { Id = Guid.NewGuid(), Format = format, LegalityName = legalityName };
            _context.MagicLegalities.Add(legality);
            _context.SaveChanges();  // Synchronous save, consider async in a real-world application
        }
        return legality;
    }

    // Other CRUD operations can be added here
}
