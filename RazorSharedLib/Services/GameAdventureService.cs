using RazorSharedLib.Interface;
using RazorSharedLib.States.GameAdventure;

namespace RazorSharedLib.Services;

public class GameAdventureService : IGameAdventureService
{
    private Dictionary<string, IGameAdventureState> gameAdventureStates;
    private IDiceGeneratorService diceGeneratorService;

    public GameAdventureService(IDiceGeneratorService diceGeneratorService)
    {
        gameAdventureStates = new Dictionary<string, IGameAdventureState>();
        this.diceGeneratorService = diceGeneratorService;
    }

    public IGameAdventureState GetState(string bookKey)
    {
        if (!gameAdventureStates.ContainsKey(bookKey))
        {
            gameAdventureStates.Add(bookKey, new GameAdventureState(bookKey));
        }

        return gameAdventureStates[bookKey];
    }

    public IGameAdventureState ResetState(string bookKey)
    {
        if (gameAdventureStates.ContainsKey(bookKey))
        {
            gameAdventureStates[bookKey] = new GameAdventureState(bookKey);
        }
        else
        {
            gameAdventureStates.Add(bookKey, new GameAdventureState(bookKey));
        }

        return gameAdventureStates[bookKey];
    }

    public void RollNewCharacter(string bookKey)
    {
        var currentState = GetState(bookKey);
        diceGeneratorService.FourD6();

        var diceArray = diceGeneratorService.State.DiceArray;
        if (diceArray is null) return;

        currentState.CharacterSheet.Skill = diceArray[0] + 6;
        currentState.CharacterSheet.Stamina = diceArray[1] + diceArray[2] + 12;
        currentState.CharacterSheet.Luck = diceArray[3] + 6;

        diceGeneratorService.ClearArray();
    }
}