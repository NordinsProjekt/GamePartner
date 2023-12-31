namespace MtGDomain.Entities;

public class Log
{
    public Guid Id { get; set; }
    public DateTime CreatedUTC { get; set; }
    public string Message { get; set; }
    public string Section { get; set; }
}