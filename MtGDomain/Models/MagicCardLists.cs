using MtGDomain.Entities;

namespace MtGDomain.Models;

public class MagicCardLists
{
    public List<MagicAbility> MagicAbilities { get; set; } = new();
    public List<MagicLegality> MagicLegality { get; set; } = new();
    public List<CardType> CardTypes { get; set; } = new();
    public List<CardSubType> CardSubType { get; set; }
    public List<SuperCardType> SuperCards { get; set; } = new();
}