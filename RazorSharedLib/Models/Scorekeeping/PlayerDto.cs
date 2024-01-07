namespace RazorSharedLib.Models.Scorekeeping;

public class PlayerDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Score { get; set; }

    public PlayerDto()
    {
    }

    public PlayerDto(string name, int score)
    {
        Id = Guid.NewGuid();
        Name = name;
        Score = score;
    }
}