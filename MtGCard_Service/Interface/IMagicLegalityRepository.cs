using MtGDomain.Entities;

namespace MtGCard_Service.Interface
{
    public interface IMagicLegalityRepository
    {
        MagicLegality FindOrCreateLegality(string format, string legalityName);
    }
}