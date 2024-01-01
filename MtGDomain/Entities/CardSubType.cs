namespace MtGDomain.Entities;

public class CardSubType
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<CardTypeMagicCard> MagicCards { get; set; }
}