using MagicRepositories.Includes;
using Microsoft.EntityFrameworkCore;
using MtGCard_Service.Interface;
using MtGDomain.Entities;

namespace MagicRepositories.Repositories;

public class MagicSetRepository : IMagicSetRepository
{
    private readonly PortalContext _context;

    public MagicSetRepository(PortalContext context)
    {
        _context = context;
    }

    public async Task<Guid> FindOrCreateSet(string setName, string setCode)
    {
        var set = _context.MagicSets.FirstOrDefault(s => s.SetCode == setCode);
        if (set == null)
        {
            set = new MagicSet { Id = Guid.NewGuid(), SetName = setName, SetCode = setCode };
            _context.MagicSets.Add(set);
            await _context.SaveChangesAsync();
                    
        }
        return set.Id;
    }

    public async Task<bool> FindSetBySetCode(string setCode)
    {
        var result = await _context.MagicSets.FirstOrDefaultAsync(x=>x.SetCode.Equals(setCode));
        return result is not null;
    }

    public async Task<MagicSet?> GetSetByCode(string setCode)
    {
        var set = await _context.MagicSets.Include(x=>x.MagicCards).FirstOrDefaultAsync(x => x.SetCode.Equals(setCode));
        if (set is null)
        {
            return null;
        }

        var cards = await _context.MagicCards
            .Include(x => x.SuperCardTypes).ThenInclude(x=>x.SuperCardType)
            .Include(x => x.Abilities).ThenInclude(x=>x.MagicAbility)
            .Include(x => x.CardTypes).ThenInclude(x=>x.CardType)
            .Include(x=>x.MagicLegalities).ThenInclude(x=>x.MagicLegality)
            .Where(card => card.MagicSetId == set.Id)
            .ToListAsync();

        return new()
        {
            Id = set.Id,
            SetCode = set.SetCode,
            SetName = set.SetName,
            MagicCards = cards.ToList()
        };
    }

    public async Task<MagicSet?> GetSetQuizCardsByCode(string setCode)
    {
        var setWithCards = await _context.MagicSets
            .Where(x => x.SetCode.Equals(setCode))
            .Select(s => new
            {
                Set = s,
                Cards = s.MagicCards.AsQueryable().QuizVersion().Where(mc => mc.MagicSetId == s.Id)
            })
            .AsNoTracking()  // Use AsNoTracking for read-only scenarios for better performance
            .FirstOrDefaultAsync();

        // Check for null early and return
        if (setWithCards == null || setWithCards.Set == null) {
            return null;
        }

        // Attach the filtered cards to the set
        var set = setWithCards.Set;
        set.MagicCards = await setWithCards.Cards.ToListAsync();

        return set;
    }

    public async Task<List<MagicSet>> GetAll()
    {
        return _context.MagicSets.Select(x => new MagicSet() { SetCode = x.SetCode, SetName = x.SetName })
            .OrderBy(x => x.SetName).ToList();
    }
}
