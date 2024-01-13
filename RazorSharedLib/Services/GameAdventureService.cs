using RazorSharedLib.Interface;
using RazorSharedLib.States.GameAdventure;

namespace RazorSharedLib.Services;

public class GameAdventureService : IGameAdventureService
{
    private Dictionary<string, IGameAdventureState> gameAdventureStates;

    public GameAdventureService()
    {
        gameAdventureStates = new Dictionary<string, IGameAdventureState>();
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
}