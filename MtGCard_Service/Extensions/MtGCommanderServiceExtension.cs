using MtGCard_Service.Classes;
using MtGCard_Service.Exceptions;

namespace MtGCard_Service.Extensions
{
    public static class MtGCommanderServiceExtension
    {
        public static MtGPlayer GetPlayer(this MtGCommanderService com, int playerId)
        {
            if (com.CheckPlayerIndex(playerId))
                return com.players[playerId];
            else
                throw new PlayerIndexException("Player doesnt exist", playerId);
        }
    }
}
