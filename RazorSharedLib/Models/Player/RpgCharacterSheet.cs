namespace RazorSharedLib.Models.Player;

public class RpgCharacterSheet
{
    public string Name { get; set; }

    public int Stamina { get; set; }
    public int StaminaModifier { get; set; }

    public int Skill { get; set; }
    public int SkillModifier { get; set; }

    public int Luck { get; set; }
    public int LuckModifier { get; set; }

    public int GoldPieces { get; set; }

    public string Notes { get; set; }

    public RpgCharacterSheet()
    {
    }
}