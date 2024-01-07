namespace MtGDomain.Entities;

public class CardType
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<CardTypeMagicCard> MagicCards { get; set; }
}