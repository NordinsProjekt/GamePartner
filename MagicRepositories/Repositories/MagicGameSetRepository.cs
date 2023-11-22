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

    public async Task<MagicSet> FindOrCreateSet(string setName, string setCode)
    {
        var set = _context.MagicSets.FirstOrDefault(s => s.SetCode == setCode);
        if (set == null)
        {
            set = new MagicSet { Id = Guid.NewGuid(), SetName = setName, SetCode = setCode };
            _context.MagicSets.Add(set);
            await _context.SaveChangesAsync();  // Synchronous save, consider async in a real-world application
        }
        return set;
    }

    // Other CRUD operations can be added here
}
