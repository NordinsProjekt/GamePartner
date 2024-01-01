namespace MtGDomain.Entities;

public class CardSubTypeMagicCard
{
    public Guid Id { get; set; }
    public Guid CardSubTypeId { get; set; }
    public CardSubType CardSubType { get; set; }

    public Guid MagicCardId { get; set; }
    public MagicCard MagicCard { get; set; }
}