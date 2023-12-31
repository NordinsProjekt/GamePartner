namespace MtGCard_Service.Models;

public sealed record LogRecordDto(DateTime CreatedUTC, string section, string message);