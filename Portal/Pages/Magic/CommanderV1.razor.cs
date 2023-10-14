using ApplicationLayer.MtGCard_Service.DTO;
using ApplicationLayer.MtGCard_Service;
using Microsoft.AspNetCore.Components;
using ApplicationLayer.MtGCard_Service.Interface;
using Microsoft.JSInterop;
using MtGCard_Service.DTO;
using MtGCard_Service;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Domain.MtGDomain.DTO;

namespace Portal.Pages.Magic
{
    public partial class CommanderV1
    {
        [Inject] IMtGCardRepository? Rep { get; set; }
        [Inject] IJSRuntime? JsRuntime { get; set; }

        List<MtGCardRecordDTO> searchResult = new List<MtGCardRecordDTO>();
        MtGCardRecordDTO? clickedCard;
        public List<MtGPlayerLife_DTO> playerList = new List<MtGPlayerLife_DTO>();

        [BindRequired]
        public int playerId { get; set; }
        string? SearchText { get; set; }

        protected override void OnInitialized()
        {
            for (int i = 0; i < 4; i++)
                playerList.Add(MtGPlayerService.MakeNewPlayer(i, "Player " + (i + 1), 40, 0, new()));
        }
        public async void Search()
        {
            if (Rep is null) throw new ArgumentNullException(nameof(Rep));

            MtGCardService mtg = new MtGCardService(Rep);
            if (SearchText !="")
            {
                searchResult = await mtg.GetCardByName(SearchText);
                clickedCard = default(MtGCardRecordDTO);
                StateHasChanged();
            }
        }

        public async void ShowCard(string id)
        {
            clickedCard = searchResult.Where(x => x.Id == id).FirstOrDefault();
            await JsRuntime!.InvokeVoidAsync("OnScrollEvent");
            StateHasChanged();
        }

        public void SaveCard()
        {
            if (clickedCard!= null && playerId > 3 == false && 0 > playerId == false)
            {
                playerList[playerId].CardList.Add(clickedCard);
            }
        }
        public void DeleteCard(string cardId,int playerId)
        {
            var card = playerList[playerId].CardList.Where(x => x.Id == cardId).FirstOrDefault();
            if (card != null)
                playerList[playerId].CardList.Remove(card);
            StateHasChanged();
        }
    }
}
