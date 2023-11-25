using Microsoft.EntityFrameworkCore;
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

    public async Task<MagicCardMagicLegality> FindOrCreateLegality(string format, string legalityName, Guid cardId)
    {

        var legality = await _context.MagicLegality.FirstOrDefaultAsync(l => l.Format == format && l.LegalityName == legalityName);
        if (legality == null)
        {
            legality = new MagicLegality { Id = Guid.NewGuid(), Format = format, LegalityName = legalityName };
            _context.MagicLegality.Add(legality);
            await _context.SaveChangesAsync();
        }

        return new() { MagicLegalityId = legality.Id, MagicCardId = cardId };
    }
}
