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

    public RpgCharacterSheet()
    {
    }

    public RpgCharacterSheet(string name)
    {
        Name = name;
    }

    public RpgCharacterSheet(string name, int stamina, int skill, int luck, int goldPieces)
    {
        Name = name;
        Stamina = stamina;
        Skill = skill;
        Luck = luck;
        GoldPieces = goldPieces;
    }

    public RpgCharacterSheet(string name, int stamina, int staminaModifier, int skill, int skillModifier, int luck,
        int luckModifier, int goldPieces)
    {
        Name = name;
        Stamina = stamina;
        StaminaModifier = staminaModifier;
        Skill = skill;
        SkillModifier = skillModifier;
        Luck = luck;
        LuckModifier = luckModifier;
        GoldPieces = goldPieces;
    }
}