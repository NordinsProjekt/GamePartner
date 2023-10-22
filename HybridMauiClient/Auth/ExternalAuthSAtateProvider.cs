using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Identity.Client;
using System.Security.Claims;

namespace HybridMauiClient.Auth
{
    public class ExternalAuthStateProvider : AuthenticationStateProvider
    {
        private ClaimsPrincipal currentUser = new ClaimsPrincipal(new ClaimsIdentity());
        private readonly IPublicClientApplication authenticationClient;
        public override Task<AuthenticationState> GetAuthenticationStateAsync() =>
            Task.FromResult(new AuthenticationState(currentUser));
        public ExternalAuthStateProvider()
        {
            authenticationClient = PublicClientApplicationBuilder.Create("81793abd-11bb-4f80-96b4-c8042d70fd7e")
            //.WithB2CAuthority(Constants.AuthoritySignIn) // uncomment to support B2C
            .WithRedirectUri($"msal81793abd-11bb-4f80-96b4-c8042d70fd7e://auth")
            //.WithRedirectUri($"https://0.0.0.0/")
            .Build();
        }
        public Task LogInAsync()
        {
            var loginTask = LogInAsyncCore();
            NotifyAuthenticationStateChanged(loginTask);

            return loginTask;

            async Task<AuthenticationState> LogInAsyncCore()
            {
                var user = await LoginWithExternalProviderAsync();
                currentUser = user;

                return new AuthenticationState(currentUser);
            }
        }

        public async Task<ClaimsPrincipal> LoginWithExternalProviderAsync()
        {
            AuthenticationResult result;
            try
            {
                result = await authenticationClient
                    .AcquireTokenInteractive(new[] { "api://87b04e25-b05b-474f-9dd3-2f6a25e4246b/access_as_user" })
                    .WithTenantId("d05efe07-0c87-4807-999a-453de1e95d3b")
                    .WithPrompt(Prompt.Consent)
                #if ANDROID
                                .WithParentActivityOrWindow(Platform.CurrentActivity)
                                .WithUseEmbeddedWebView(false)

                #endif
                    .ExecuteAsync()
                    .ConfigureAwait(false);
            }

            catch (Exception ex)
            {
                return null;
            }
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity());

            return authenticatedUser;
        }

        public void Logout()
        {
            currentUser = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(
                Task.FromResult(new AuthenticationState(currentUser)));
        }
    }
}
