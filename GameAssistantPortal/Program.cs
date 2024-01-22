using GameAssistantPortal.Components;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Identity.Web;
using RazorSharedLib.Api;
using RazorSharedLib.Extensions;
using RazorSharedLib.States.Buffer;

namespace GameAssistantPortal;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents()
            .AddMicrosoftIdentityConsentHandler();

        builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));
        builder.Services.AddAuthorization(options =>
        {
            // Allows anonymous access by default, only requiring authentication for [Authorize]-marked components
            options.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAssertion(_ => true).Build();
        });

        builder.Services.AddHttpClient<ApiClient>((serviceProvider, client) => { }).ConfigureHttpClient(
            (serviceProvider, client) =>
            {
                // Optionally configure other settings for the HttpClient
            });

        builder.Services.AddTransient(serviceProvider =>
        {
            // Resolve the HttpClientFactory created above
            var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
            var client = httpClientFactory.CreateClient(nameof(ApiClient));

            // Create an instance of ApiClient with the HttpClient and base URL
            return new ApiClient("https://api.gameassistant.se", client);
        });

        builder.Services.AddStates();
        builder.Services.AddServices();

        var app = builder.Build();

        var magicBufferState = app.Services.GetRequiredService<IMagicBufferState>();
        var apiClient = app.Services.GetRequiredService<ApiClient>();

        // Call the InitializeAsync method
        var bufferInitTask = magicBufferState.InitializeAsync(apiClient);

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}