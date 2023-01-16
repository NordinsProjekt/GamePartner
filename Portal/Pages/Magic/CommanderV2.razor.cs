using Microsoft.JSInterop;
using MtGCard_Service.DTO;
using System.Runtime.CompilerServices;

namespace Portal.Pages.Magic
{
    public partial class CommanderV2
    {
        string SearchText { get; set; }
        private bool ShowClickedCardResult { get; set; } = false;
        private bool ShowCardPager { get; set; } = true;
        private bool ShowPlayerCards { get; set; } = true;
        public bool ShowProgress { get; set; } = false;
        private async void SearchForCard()
        {
            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                ShowProgress= true;
                await _commanderService.SearchForCard(SearchText);
                ShowProgress= false;
                StateHasChanged();
            }
        }

        private void SwitchCardPager()
        {
            if (ShowCardPager == true)
                ShowCardPager = false;
            else
                ShowCardPager = true;
        }
        private void SwitchPlayerCards()
        {
            if (ShowPlayerCards == true)
                ShowPlayerCards = false;
            else
                ShowPlayerCards = true;
        }
        private void ClearFields()
        {
            _commanderService.ClearClickedCard();
            //_commanderService.ClearSearchResult();
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
        public void Top10() //Buggig
        {
            if (ShowClickedCardResult == true)
                ShowClickedCardResult = false;
            else
                ShowClickedCardResult = true;
        }
    }
}
