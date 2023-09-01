using ApplicationLayer.MtGCard_Service.Interface;
using Infrastructure.MtGCard_API;
using Microsoft.Extensions.Logging;
using MtgApiManager.Lib.Service;
using MtGCard_API;
using MtGCard_Service.Interface;
using MtGCard_Service;
using GenerateGuid.Extensions;
using MtGCard_Service.Extensions;

namespace HybridMauiClient
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddTransient<IMtgServiceProvider, MtgServiceProvider>();
            builder.Services.AddTransient<IMtGCardRepository, SearchForCard>();
            builder.Services.AddTransient<IMtGQuizService, MtGQuizService>();
            builder.Services.AddSingleton<IMtGSearchBuffer, SearchBuffer>();
            builder.Services.AddSingleton<ICardSetBuffer, CardSetBuffer>();
            builder.Services.AddMtGBoardState();
            builder.Services.AddGuidGenerator();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}