using Microsoft.JSInterop;
using MtGCard_Service.DTO;
using System.Runtime.CompilerServices;

namespace Portal.Pages.Magic
{
    public partial class CommanderV2
    {
        string SearchText { get; set; }
        private bool ShowClickedCardResult { get; set; } = false;
        private async void SearchForCard()
        {
            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                await _commanderService.SearchForCard(SearchText);
                StateHasChanged();
            }
        }
        private void ClearFields()
        {
            _commanderService.ClearClickedCard();
            _commanderService.ClearSearchResult();
            StateHasChanged();
        }
        protected async void ShowCard(string cardId)
        {
            _commanderService.SetClickedCard(cardId);
            await JS.InvokeVoidAsync("OnScrollEvent");
            StateHasChanged();
        }
        protected void AddCardToPlayer(int id)
        {
            _commanderService.AddCardToPlayer(id, _commanderService.GetClickedCard());
            ClearFields();
        }
        protected void DeleteCard(MtGDeleteCard_DTO playerCard) =>
            _commanderService.RemoveCardFromPlayer(playerCard.PlayerIndex,playerCard.CardId);
        public void Top10()
        {
            if (ShowClickedCardResult == true)
                ShowClickedCardResult = false;
            else
                ShowClickedCardResult = true;
        }
    }
}
