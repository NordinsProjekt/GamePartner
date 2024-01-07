using Microsoft.EntityFrameworkCore;
using MtGCard_Service.Interface;
using MtGDomain.Entities;

namespace MagicRepositories.Repositories;

public class MagicLegalityRepository : IMagicLegalityRepository
{
    private readonly PortalContext _context;

    public MagicLegalityRepository(PortalContext context)
    {
        _context = context;
    }

    public async Task<MagicCardMagicLegality> CreateLegality(string format, string legalityName, Guid cardId)
    {
        var legality = new MagicLegality { Id = Guid.NewGuid(), Format = format, LegalityName = legalityName };

        _context.MagicLegality.Add(legality);
        _context.Logs.Add(new Log()
        {
            CreatedUTC = DateTime.UtcNow,
            Id = Guid.NewGuid(),
            Message = $"Adding Legality {format} - {legalityName}",
            Section = "Magic"
        });
        await _context.SaveChangesAsync();

        return new() { MagicLegalityId = legality.Id, MagicCardId = cardId };
    }

    public async Task<List<MagicLegality>> GetAll()
    {
        return await _context.MagicLegality.AsNoTracking().ToListAsync();
    }
}