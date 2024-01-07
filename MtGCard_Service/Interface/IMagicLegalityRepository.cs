using MtGDomain.Entities;

namespace MtGCard_Service.Interface;

public interface IMagicLegalityRepository
{
    Task<MagicCardMagicLegality> CreateLegality(string format, string legalityName, Guid cardId);
    Task<List<MagicLegality>> GetAll();
}