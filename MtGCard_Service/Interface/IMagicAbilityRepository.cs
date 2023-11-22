using MtGDomain.Entities;

namespace MtGCard_Service.Interface
{
    public interface IMagicAbilityRepository
    {
        MagicAbility FindOrCreateAbility(string abilityName);
    }
}