using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MtGCard_Service;
using MtGCard_Service.Classes.Extensions;
using MtGCard_Service.DTO;
using MtGCard_Service.Extensions;
using System.Reflection;

namespace Portal.Pages.Magic
{
    public partial class LifeCounter
    {
        [Inject]
        IJSRuntime JsRuntime { get; set; }
        [Inject]
        NavigationManager NavManager { get; set; }
        public async Task Damage(int playerId,int damage)
        {
            _commanderService.GetPlayer(playerId).DoDamage(damage);
            await DrawLifeCounter(playerId);
        }
            
        public async Task Heal(int playerId,int heal)
        {
            _commanderService.GetPlayer(playerId).Heal(heal);
            await DrawLifeCounter(playerId);
        }
            
        public async Task Poison(int playerId, int poison)
        {
            _commanderService.PlayerTakesPoisonDamage(playerId, poison);
            await DrawPoisonCounter(playerId);
        }
            
        public async Task HealPoison(int playerId, int poison)
        {
            _commanderService.PlayerHealsPoisonDamage(playerId, poison);
            await DrawPoisonCounter(playerId);
        }
            
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var players = _commanderService.GetPlayerList();
                int numPlayers = _commanderService.PlayerCount;
                if (numPlayers == 0)
                    NavManager.NavigateTo("/", false);
                for (int i = 0; i < numPlayers; i++)
                {
                    string[] arr = new string[2] { _commanderService.GetPlayerLifeTotal(i).ToString(), "life_" + players[i].PlayerId };
                    await JsRuntime.InvokeVoidAsync("DrawLifeCounter", arr);
                    arr = new string[2] { _commanderService.GetPlayerPoisonCountTotal(i).ToString(), "poison_" + players[i].PlayerId };
                    await JsRuntime.InvokeVoidAsync("DrawPoisonCounter", arr);
                }
            }
        }
        public async Task DrawLifeCounter(int playerId)
        {
            string[] arr = new string[2] { _commanderService.GetPlayerLifeTotal(playerId).ToString(), "life_" + playerId };
            await JsRuntime.InvokeVoidAsync("DrawLifeCounter", arr);
        }

        public async Task DrawPoisonCounter(int playerId)
        {
            string[] arr = new string[2] { _commanderService.GetPlayerPoisonCountTotal(playerId).ToString(), "poison_" + playerId };
            await JsRuntime.InvokeVoidAsync("DrawPoisonCounter", arr);
        }
    }
}
