using MagicRepositories.Includes;
using Microsoft.EntityFrameworkCore;
using MtGCard_Service.Interface;
using MtGDomain.Entities;

namespace MagicRepositories.Repositories;

public class MagicCardRepository : IMagicCardRepository
{
    private readonly PortalContext _context;

    public MagicCardRepository(PortalContext context)
    {
        _context = context;
    }

    // Create
    public async Task AddAsync(MagicCard card)
    {
        _context.MagicCards.Add(card);

        await _context.SaveChangesAsync();
    }

    // Read
    public async Task<MagicCard?> GetByIdAsync(Guid id)
    {
            return await _context.MagicCards
                .AllIncludes()
                .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<MagicCard?> GetByIdWithQuizIncludes(Guid id)
    {
        return await _context.MagicCards
            .QuizVersion()
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    // Update
    public async Task UpdateAsync(MagicCard card)
    {
        _context.MagicCards.Update(card);
            await _context.SaveChangesAsync();
    }
}
