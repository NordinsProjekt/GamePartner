using MagicRepositories.Repositories;
using Microsoft.Extensions.DependencyInjection;
using MtGCard_Service.Interface;

namespace MagicRepositories.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection service)
        {
            service.AddTransient<IMagicSetRepository, MagicSetRepository>();
            service.AddTransient<ICardTypeRepository, CardTypeRepository>();
            service.AddTransient<ISuperCardTypeRepository, SuperCardTypeRepository>();
            service.AddTransient<IMagicAbilityRepository, MagicAbilityRepository>();
            service.AddTransient<IMagicLegalityRepository, MagicLegalityRepository>();
            service.AddTransient<ILogRepository, LogRepository>();
            service.AddTransient<ICardSubTypeRepository, CardSubTypeRepository>();
        }
    }
}