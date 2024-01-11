using Microsoft.Extensions.DependencyInjection;
using RazorSharedLib.Interface;
using RazorSharedLib.Services;
using RazorSharedLib.States.Buffer;
using RazorSharedLib.States.GameAssets;
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
        service.AddScoped<IDiceGeneratorState, DiceGeneratorState>();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IDiceGeneratorService, DiceGeneratorService>();
    }
}