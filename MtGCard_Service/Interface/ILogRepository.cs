using MtGDomain.Entities;

namespace MtGCard_Service.Interface;

public interface ILogRepository
{
    Task CreateLog(string section, string message);
    List<Log> GetLatest50LogEntries();
}