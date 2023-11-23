using MtGCard_Service.DTO;
using Domain.MtGDomain.DTO;
using MtGCard_Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_Service
{
    public static class MtGPlayerService
    {
        public static MtGPlayerLife_DTO MakeNewPlayer(int playerId, string? playerName, int playerLifeTotal, int playerPoisonTotal, List<MtGCardRecordDTO> cardList = null)
        {
            return new MtGPlayerLife_DTO(playerId, playerName, playerLifeTotal, playerPoisonTotal, new List<MtGCardRecordDTO>());
        }
    }
}
