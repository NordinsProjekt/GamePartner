using Domain.MtGDomain.DTO;

namespace MtGDomain.DTO;

public sealed record MtGCardSet(List<MtGCardRecordDTO> List, string SetName, string SetCode);