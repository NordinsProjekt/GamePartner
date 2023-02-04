using Microsoft.JSInterop;
using Domain.MtGDomain.DTO;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Components;

namespace Portal.Pages.Magic
{
    public partial class CommanderV2
    {
        [Inject]
        NavigationManager NavManager { get; set; }
        string SearchText { get; set; }
        private bool ShowClickedCardResult { get; set; } = false;
        private bool ShowCardPager { get; set; } = true;
        
        public bool ShowProgress { get; set; } = false;
        private async void SearchForCard()
        {
            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                //Bygg ihop buffer och commanderservice till en lista. Det blir fel överallt.
                ShowProgress = true;
                await CommanderService.SearchForCard(SearchText);
                //await _buffer.PopulateCardList(SearchText);
                ShowProgress= false;
                StateHasChanged();
            }
        }
        protected override void OnAfterRender(bool firstRender)
        {
            int numOfPlayers = CommanderService.PlayerCount;
            if (numOfPlayers == 0)
                NavManager.NavigateTo("/", false);
        }
        private void SwitchCardPager()
            => ShowCardPager = SwitchValues(ShowCardPager);
        private void ClearFields()
        {
            CommanderService.ClearClickedCard();
            StateHasChanged();
        }
        //Lägg till kort i commanderService istället för buffer.
        protected async void ShowCard(string cardId)
        {
            CommanderService.SetClickedCard(cardId);
            await JS.InvokeVoidAsync("OnScrollEvent");
            StateHasChanged();
        }
        protected void AddCardToPlayer(int id)
        {
            CommanderService.AddCardToPlayer(id, CommanderService.GetClickedCard());
            ClearFields();
        }

        public void Top10() //Buggig
        {
            if (ShowClickedCardResult == true)
                ShowClickedCardResult = false;
            else
                ShowClickedCardResult = true;
        }

        private bool SwitchValues(bool value)
            => value? false : true;
    }
}
