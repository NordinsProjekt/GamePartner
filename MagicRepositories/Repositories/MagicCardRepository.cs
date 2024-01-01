using MagicRepositories.Includes;
using Microsoft.EntityFrameworkCore;
using MtGCard_Service.Interface;
using MtGDomain.Entities;
using MtGDomain.Models;

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

    public async Task AddAllAsync(List<MagicCard> cards)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            //
            try
            {
                await _context.MagicCards.AddRangeAsync(cards);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
                Console.WriteLine(e);
                throw;
            }
        }
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

    public async Task<MagicCardLists> GetAllListsForCard()
    {
        return new()
        {
            CardTypes = await _context.CardType.AsNoTracking().ToListAsync(),
            SuperCards = await _context.SuperCardTypes.AsNoTracking().ToListAsync(),
            MagicAbilities = await _context.MagicAbility.AsNoTracking().ToListAsync(),
            MagicLegality = await _context.MagicLegality.AsNoTracking().ToListAsync(),
            CardSubType = await _context.CardSubType.AsNoTracking().ToListAsync()
        };
    }
}