using Microsoft.Extensions.DependencyInjection;
using RazorSharedLib.Api;
using RazorSharedLib.Interface;
using RazorSharedLib.States.Buffer;
using RazorSharedLib.States.Player;
using RazorSharedLib.States.Quiz;

namespace RazorSharedLib.Extensions;

public static class IServiceCollectionExtensions
{
    public static void AddStates(this IServiceCollection service)
    {
        service.AddSingleton<IMagicBufferState, MagicBufferState>();
        service.AddScoped<IPlayerState, PlayerState>();
        service.AddScoped<IMagicQuizState, MagicQuizState>();
    }
}