using GenerateGuid.Interfaces;
using GenerateGuid.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GenerateGuid.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddGuidGenerator(this IServiceCollection service)
        {
            service.AddTransient<IGuidGeneratorService, GuidGeneratorService>();
        }
    }
}
