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

    public async Task<MagicAbilityMagicCard> FindOrCreateAbility(string abilityName, Guid cardId)
    {
        try
        {
            var ability = _context.MagicAbility.FirstOrDefault(a => a.Name == abilityName);
            if (ability == null)
            {
                ability = new MagicAbility { Id = Guid.NewGuid(), Name = abilityName };
                _context.MagicAbility.Add(ability);
                await _context.SaveChangesAsync();
            }

            return new() { MagicAbilityId = ability.Id, MagicCardId = cardId };
        }
        catch (Exception ex)
        {
            throw;
        }

    }
}
