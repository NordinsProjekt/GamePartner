using MtGDomain.Entities;

namespace MtGCard_Service.Interface
{
    public interface IMagicLegalityRepository
    {
        Task<MagicCardMagicLegality> FindOrCreateLegality(string format, string legalityName, Guid cardId);
    }
}