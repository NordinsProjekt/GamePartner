using Microsoft.Extensions.DependencyInjection;
using RazorSharedLib.Interface;
using RazorSharedLib.States.Player;

namespace RazorSharedLib.Extensions;

public static class IServiceCollectionExtensions
{
    public static void AddStates(this IServiceCollection service)
    {
        service.AddScoped<IPlayerState, PlayerState>();
    }
}