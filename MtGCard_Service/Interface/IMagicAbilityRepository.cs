using MtGDomain.Entities;

namespace MtGCard_Service.Interface
{
    public interface IMagicAbilityRepository
    {
        Task<MagicAbilityMagicCard> FindOrCreateAbility(string abilityName, Guid cardId);
    }
}