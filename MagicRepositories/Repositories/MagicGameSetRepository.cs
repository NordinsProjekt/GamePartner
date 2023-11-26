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
}
