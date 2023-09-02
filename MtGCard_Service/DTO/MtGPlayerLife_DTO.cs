using ApplicationLayer.MtGCard_Service.DTO;
using Domain.MtGDomain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_Service.DTO
{
    public class MtGPlayerLife_DTO
    {
        public int PlayerId { get; set; }
        public string? PlayerName { get; set; }
        public int PlayerLifeTotal { get; set; }
        public int PlayerPoisonCountTotal { get; set; }
        public List<MtGCardRecordDTO> CardList { get; set; } = new();

        public MtGPlayerLife_DTO(int playerId, string? playerName,int playerLifeTotal, int playerPoisonCountTotal, List<MtGCardRecordDTO> cardList)
        { 
            PlayerId= playerId;
            PlayerName= playerName;
            PlayerLifeTotal= playerLifeTotal;
            PlayerPoisonCountTotal= playerPoisonCountTotal;
            if (cardList != null)
                CardList = cardList.ToList();
        }

    }
}
