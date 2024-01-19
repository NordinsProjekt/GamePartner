namespace RazorSharedLib.Interface;

public interface IGameAdventureService
{
    IGameAdventureState GetState(string bookKey);
    IGameAdventureState ResetState(string bookKey);
    void RollNewCharacter(string bookKey);
}