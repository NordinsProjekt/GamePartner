using MtGCard_Service.Classes;
using MtGCard_Service.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
