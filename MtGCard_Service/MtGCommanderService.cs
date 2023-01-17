using Application.MtGCard_Service.DTO;
using Application.MtGCard_Service.Interface;
using MtGCard_Service.Classes;
using MtGCard_Service.Classes.Extensions;
using MtGCard_Service.DTO;
using MtGCard_Service.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_Service
{
    public class MtGCommanderService
    {
        public List<MtGPlayer> players = new List<MtGPlayer>();
        private List<MtGCardRecordDTO> searchResult = new List<MtGCardRecordDTO>();
        private MtGCardRecordDTO? clickedCard = null;
        private IMtGCardRepository _context;
        private IMtGSearchBuffer? _bufferContext = null;
        public MtGCommanderService(IMtGCardRepository _rep) => _context = _rep;
        public MtGCommanderService(IMtGCardRepository _rep,IMtGSearchBuffer _buff) 
        {
            _context = _rep;
            _bufferContext = _buff;
        }
        public MtGCommanderService(IMtGCardRepository _rep, int numOfPlayers)
        {
            _context = _rep;
            CreatePlayers(numOfPlayers);
        }

        public void CreateNumPlayers(int numOfPlayers) => CreatePlayers(numOfPlayers);
        public int PlayerCount
        {
            get { return players.Count; }
        }

        public List<MtGPlayerRecord_DTO> GetPlayerList()
        {
            List<MtGPlayerRecord_DTO> list = new List<MtGPlayerRecord_DTO>();
            foreach (var player in players) 
                list.Add(new MtGPlayerRecord_DTO(player.GetPlayerId, player.GetPlayerName));
            return list;
        }

        public List<MtGPlayerWithCardListRecord_DTO> GetPlayerListWithCardList()
        {
            List<MtGPlayerWithCardListRecord_DTO> list = new List<MtGPlayerWithCardListRecord_DTO>();
            foreach (var player in players)
                list.Add(new MtGPlayerWithCardListRecord_DTO(player.GetPlayerId, player.GetPlayerName, GetPlayerCardList(player.GetPlayerId)));
            return list;
        }

        public int SearchResultCount
        {
            get { return searchResult.Count; }
        }

        public List<MtGCardRecordDTO> GetSearchResult() => searchResult.ToList();

        public int GetPlayerLifeTotal(int playerIndex)
        {
            CheckPlayerIndex(playerIndex);
            return players[playerIndex].LifeTotal;
        }

        public int GetPlayerPoisonCountTotal(int playerIndex)
        {
            CheckPlayerIndex(playerIndex);
            return players[playerIndex].GetPlayerPoisonCount;

        }

        public int GetPlayerCommanderDamageFromSpecifikPlayer(int playerIndex,int playerCommanderIndex)
        {
            CheckPlayerIndex(playerIndex);
            CheckPlayerIndex(playerCommanderIndex);
            return players[playerIndex].GetPlayerCommanderDamage(playerCommanderIndex);
        }


        public void PlayerTakesDamage(int playerIndex,int damage)
        {
            CheckPlayerIndex(playerIndex);
            players[playerIndex].DoDamage(damage);
        }

        public void PlayerTakesPoisonDamage(int playerIndex,int poisonDamage)
        {
            CheckPlayerIndex(playerIndex);
            players[playerIndex].TakePoisonDamage(poisonDamage);
        }
        public void PlayerGainLife(int playerIndex,int lifeGain)
        {
            CheckPlayerIndex(playerIndex);
            players[playerIndex].Heal(lifeGain);
        }
        public void PlayerHealsPoisonDamage(int playerIndex,int poisonDamageReduced)
        {
            CheckPlayerIndex(playerIndex);
            players[playerIndex].RemovePoisonCounters(poisonDamageReduced);
        }

        public void PlayerTakesCommanderDamage(int playerIndex,int playerCommanderIndex,int commanderDamage)
        {
            CheckPlayerIndex(playerIndex);
            CheckPlayerIndex(playerCommanderIndex);
            players[playerIndex].TakeCommanderDamage(playerCommanderIndex, commanderDamage);
        }

        public void PlayerHealsCommanderDamage(int playerIndex,int playerCommanderIndex,int commanderDamageReduced)
        {
            CheckPlayerIndex(playerIndex);
            CheckPlayerIndex(playerCommanderIndex);
            players[playerIndex].HealCommanderDamage(playerCommanderIndex, commanderDamageReduced);
        }

        public void AddCardToPlayer(int playerIndex,MtGCardRecordDTO card)
        {
            CheckPlayerIndex(playerIndex);
            if (card != null)
                players[playerIndex].AddCardToList(card);
        }

        public List<MtGCardRecordDTO> GetPlayerCardList(int playerIndex)
        {
            CheckPlayerIndex(playerIndex);
            return players[playerIndex].CardList;
        }

        public void RemoveCardFromPlayer(int playerIndex,string cardId)
        {
            CheckPlayerIndex(playerIndex);
            players[playerIndex].RemoveCardFromList(cardId);
        }

        public void SetClickedCard(string id)
        {
            var card = searchResult.Where(x=> x.Id == id).FirstOrDefault();
            if (card != null)
                clickedCard = card;
            else
            {
                if (_bufferContext != null)
                {
                    clickedCard = _bufferContext.GetCardById(id);
                }
            }
            if (_bufferContext != null && card != null)
                _bufferContext.AddClickedCard(card);
        }

        public MtGCardRecordDTO GetClickedCard() => clickedCard;

        public void ClearClickedCard() => clickedCard = null;

        public void ClearSearchResult() => searchResult = new List<MtGCardRecordDTO>();

        /// <summary>
        /// Only gives back the Unique name result and if there is a ImageUrl
        /// </summary>
        /// <param name="cardName"></param>
        /// <returns></returns>
        public async Task SearchForCard(string cardName)
        {
            //Lägg in en buffer här som kollar om kortet redan finns.
            if (string.IsNullOrWhiteSpace(cardName))
                return;
            if (_bufferContext != null)
            {
                if (SearchForCardInBuffer(cardName))
                    return;
            }
            var list = await _context.GetCardsByName(cardName);
            AddingSearchResult(list, cardName);
            return;
        }

        private void AddingSearchResult(List<MtGCardRecordDTO> list,string cardName)
        {
            searchResult = list.Where(img => img.ImageUrl != "")
                .Where(img => img.ImageUrl != null)
                .GroupBy(x => x.Name).Select(f => f.First()).ToList();
            if (_bufferContext !=null)
                _bufferContext.AddToSearchBuffer(cardName, searchResult);
        }
        private bool SearchForCardInBuffer(string cardName)
        {
            var searchBuffer = _bufferContext.SearchCard(cardName);
            if (searchBuffer.Count() > 0)
            {
                searchResult = searchBuffer;
                return true;
            }
            return false;
        }

        private void CreatePlayers(int numberOfPlayers)
        {
            if (players.Count > 0)
                players.Clear();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                MtGPlayer player = new MtGPlayer(i, "Player " + (i + 1), numberOfPlayers);
                players.Add(player);
            }
        }

        public void CreatePlayers(int numberOfPlayers, List<string> playerNames)
        {
            if (players.Count > 0)
                players.Clear();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                string name;
                if (playerNames.Count < i)
                    name = "Player "+i.ToString();
                else
                    name = playerNames[i];
                MtGPlayer player = new MtGPlayer(i,name, numberOfPlayers);
                players.Add(player);
            }
        }

        public List<MtGCardRecordDTO> GetTop10ClickedCards()
        {
            var result = _bufferContext.GetClickedCardList();
            if (result.Count() > 10)
                return result.OrderByDescending(x=>x.NumOfTimesClicked).Select(c=>c.Card).Take(10).ToList();
            return result.OrderByDescending(x => x.NumOfTimesClicked).Select(c => c.Card).ToList();
        }

        public void SetCommanderForPlayer(int playerId, string cardId)
        {
            CheckPlayerIndex(playerId);
            CheckSelectedCard(cardId);
            players[playerId].SetCommanderCard(clickedCard);
        }

        public bool CheckPlayerIndex(int playerIndex)
        {
            if (playerIndex > players.Count - 1 && playerIndex < 0)
                return false;
            return true;
        }

        public void CheckSelectedCard(string cardId) 
        {
            if (clickedCard == null || clickedCard.Id != cardId)
                throw new System.Exception("Card doesnt exist in search reult");
        }

    }
}
