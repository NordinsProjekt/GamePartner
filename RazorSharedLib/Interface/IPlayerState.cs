using RazorSharedLib.Models.Scorekeeping;

namespace RazorSharedLib.Interface;

public interface IPlayerState
{
    List<PlayerDto> GetPlayers();
    void CreatePlayers(string[] names);
}