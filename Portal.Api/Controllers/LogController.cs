using Microsoft.AspNetCore.Mvc;
using MtGCard_Service.Interface;
using MtGCard_Service.Models;

namespace MtGApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LogController : Controller
{
    private readonly ILogRepository _logRepository;

    public LogController(ILogRepository logRepository)
    {
        _logRepository = logRepository;
    }

    [HttpGet("get-top-50")]
    [ProducesResponseType(typeof(LogResponseRecordDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public LogResponseRecordDto GetTop50Latest()
    {
        var logs = _logRepository.GetLatest50LogEntries();
        var convertedLogs = logs.Select(x =>
            new LogRecordDto(x.CreatedUTC, x.Section, x.Message)).ToList();

        return new LogResponseRecordDto(convertedLogs);
    }
}