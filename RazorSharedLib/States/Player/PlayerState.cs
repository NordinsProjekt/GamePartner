using RazorSharedLib.Interface;
using RazorSharedLib.Models.Scorekeeping;

namespace RazorSharedLib.States.Player;

public class PlayerState : IPlayerState
{
    private List<PlayerDto> _players;

    public PlayerState()
    {
        _players = new List<PlayerDto>();
    }

    public List<PlayerDto> GetPlayers()
    {
        return _players;
    }
}