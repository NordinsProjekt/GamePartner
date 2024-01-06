using Microsoft.Extensions.DependencyInjection;
using RazorSharedLib.Interface;

namespace RazorSharedLib.Extensions;

public static class IServiceCollectionExtensions
{
    public static void AddStates(this IServiceCollection service)
    {
        service.AddScoped<IPlayerState, IPlayerState>();
    }
}