using Microsoft.EntityFrameworkCore;
using MtGCard_Service.Interface;
using MtGDomain.Entities;

namespace MagicRepositories.Repositories;

public class MagicAbilityRepository : IMagicAbilityRepository
{
    private readonly PortalContext _context;

    public MagicAbilityRepository(PortalContext context)
    {
        _context = context;
    }

    public async Task<MagicAbilityMagicCard> CreateAbility(string abilityName, Guid cardId)
    {
        var ability = new MagicAbility { Id = Guid.NewGuid(), Name = abilityName };

        _context.MagicAbility.Add(ability);
        await _context.SaveChangesAsync();

        return new() { MagicAbilityId = ability.Id, MagicCardId = cardId };
    }

    public async Task<List<MagicAbility>> GetAll()
    {
        return await _context.MagicAbility.AsNoTracking().ToListAsync();
    }
}