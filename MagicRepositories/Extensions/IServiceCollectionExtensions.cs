using MagicRepositories.Repositories;
using Microsoft.Extensions.DependencyInjection;
using MtGCard_Service;
using MtGCard_Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
