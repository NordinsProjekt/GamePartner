using MtGCard_Service.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MtGCard_Service.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMtGBoardState(this IServiceCollection service)
        {
            service.AddScoped<MtGCardBufferService>();
            service.AddScoped<MtGCommanderService>();
        }
    }
}
