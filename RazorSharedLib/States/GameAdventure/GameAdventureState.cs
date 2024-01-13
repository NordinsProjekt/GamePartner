using RazorSharedLib.Interface;
using RazorSharedLib.Models.Player;

namespace RazorSharedLib.States.GameAdventure;

public class GameAdventureState : IGameAdventureState
{
    public string BookTitle { get; init; }

    public RpgCharacterSheet CharacterSheet { get; init; }

    public GameAdventureState()
    {
    }

    public GameAdventureState(string bookTitle)
    {
        BookTitle = bookTitle;
        CharacterSheet = new RpgCharacterSheet();
    }

    public GameAdventureState(string bookTitle, string name, int stamina, int staminaModifier, int skill,
        int skillModifier, int luck,
        int luckModifer, int goldPieces)
    {
        BookTitle = bookTitle;

        CharacterSheet = new RpgCharacterSheet(name, stamina, staminaModifier, skill, skillModifier, luck, luckModifer,
            goldPieces);
    }
}