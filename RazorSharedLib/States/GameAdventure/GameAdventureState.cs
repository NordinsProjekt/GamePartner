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
}