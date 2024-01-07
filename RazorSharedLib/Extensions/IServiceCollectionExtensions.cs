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
        var serviceProvider = service.BuildServiceProvider();
        var apiClient = serviceProvider.GetService<ApiClient>();
        var magicSetBuffer = new MagicBufferState();

        service.AddSingleton(magicSetBuffer);
        service.AddSingleton<Task>(magicSetBuffer.InitializeAsync(apiClient));
        service.AddScoped<IPlayerState, PlayerState>();
        service.AddScoped<MagicQuizState>();
    }
}