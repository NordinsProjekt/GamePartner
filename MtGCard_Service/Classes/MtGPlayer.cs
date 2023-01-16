using Application.MtGCard_Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_Service.Classes
{
    public class MtGPlayer
    {
        private MtGCommander commander;
        private MtGPlayerInfo info;
        private MtGPlayerLife life;
        private List<MtGCardRecordDTO> cardList = new List<MtGCardRecordDTO>();

        public MtGPlayer(int playerId, string playerName, int numberOfPlayers)
        {
            info = new MtGPlayerInfo(playerId, playerName);
            life = new MtGPlayerLife(40, 0, numberOfPlayers);
        }

        public int GetPlayerLifeTotal
        {
            get { return life.PlayerLife; }
            private set { }
        }

        public int GetPlayerPoisonCount
        {
            get { return life.PlayerPoisonCount; }
        }

        public string GetPlayerName
        {
            get { return info.Name; }
        }

        public int GetPlayerId
        {
            get { return info.Id; }
        }

        public int GetPlayerCommanderDamage(int commanderPlayerIndex) => life.GetPlayerCommanderDamage(commanderPlayerIndex);

        public void TakeDamage(int damage) => life.PlayerTakeDamage(damage);
        public void TakePoisonDamage(int poisonDamage) => life.PlayerTakePoisonDamage(poisonDamage);
        public void GainLife(int lifeGain) => life.PlayerGainsLife(lifeGain);
        public void RemovePoisonCounters(int poisonCounters) => life.PlayerRemovePoisonCounters(poisonCounters);
        public void TakeCommanderDamage(int playerCommanderIndex,int commanderDamage) 
            => life.PlayerTakesCommanderDamage(playerCommanderIndex,commanderDamage);
        public void HealCommanderDamage(int playerCommanderIndex,int commanderDamage)
            => life.PlayerHealsCommanderDamage(playerCommanderIndex,commanderDamage);
        public void AddCardToList(MtGCardRecordDTO card) => cardList.Add(card);
        public void SetCommanderCard(MtGCardRecordDTO card) =>commander.SetCommanderCard(card);
        public MtGCardRecordDTO GetCommanderCard() => commander.GetCommanderCard();
        public List<MtGCardRecordDTO> CardList => cardList.ToList();
        public void RemoveCardFromList(string cardId)
        {
            MtGCardRecordDTO card = cardList.Where(x => x.Id == cardId).FirstOrDefault();
            if (card != null && cardList.Count() >0)
            {
                cardList.Remove(card);
            }
        }
    }
}
