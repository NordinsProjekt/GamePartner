using MtGCard_Service.DTO;
using Domain.MtGDomain.DTO;

namespace MtGCard_Service;

public static class MtGPlayerService
{
    public static MtGPlayerLife_DTO MakeNewPlayer(int playerId, string? playerName, int playerLifeTotal,
        int playerPoisonTotal, List<MtGCardRecordDTO> cardList = null)
    {
        return new MtGPlayerLife_DTO(playerId, playerName, playerLifeTotal, playerPoisonTotal,
            new List<MtGCardRecordDTO>());
    }
}