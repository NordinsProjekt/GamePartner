using MtGCard_Service.Interface;
using MtGDomain.Entities;

namespace MagicRepositories.Repositories;

public class LogRepository : ILogRepository
{
    private readonly PortalContext _context;

    public LogRepository(PortalContext context)
    {
        _context = context;
    }

    public async Task CreateLog(string section, string message)
    {
        var log = new Log() { CreatedUTC = DateTime.UtcNow, Section = section, Message = message };
        await _context.AddAsync(log);
        await _context.SaveChangesAsync();
    }

    public List<Log> GetLatest50LogEntries()
    {
        return _context.Logs.OrderByDescending(x => x.CreatedUTC).Take(50).ToList();
    }
}