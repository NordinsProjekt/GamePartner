using Domain.MtGDomain.DTO;

namespace MtGCard_Service.Models;

public sealed record SingleMagicSetResponseRecordDto(string SetName, string SetCode, List<MtGCardRecordDTO> Cards);