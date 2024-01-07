using MtGDomain.Entities;

namespace MtGCard_Service.Interface;

public interface IMagicAbilityRepository
{
    Task<MagicAbilityMagicCard> CreateAbility(string abilityName, Guid cardId);
    Task<List<MagicAbility>> GetAll();
}