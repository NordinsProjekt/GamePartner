using RazorSharedLib.Models.Player;

namespace RazorSharedLib.Interface;

public interface IGameAdventureState
{
    string BookTitle { get; init; }
    RpgCharacterSheet CharacterSheet { get; init; }
}