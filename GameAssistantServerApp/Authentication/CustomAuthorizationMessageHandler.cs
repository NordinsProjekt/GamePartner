using Microsoft.Identity.Web;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace GameAssistantServerApp.Authentication;

public class CustomAuthorizationMessageHandler(
    ITokenAcquisition tokenAcquisition,
    IHttpContextAccessor httpContextAccessor)
    : DelegatingHandler
{
    private ClaimsPrincipal? User => httpContextAccessor.HttpContext?.User;

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        if (User?.Identity != null && (User is null || !User.Identity.IsAuthenticated))
        {
            await base.SendAsync(request, cancellationToken);
        }

        // Acquire the token
        try
        {
            var accessToken =
                await tokenAcquisition.GetAccessTokenForUserAsync(new[]
                    { "api://f4ff1258-a8c4-40c4-b132-e0ad1b4d390c/Log.Read" });
            // Modify the request here
            request.Headers.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            // Call the inner handler
            return await base.SendAsync(request, cancellationToken);
        }
        catch (Exception e)
        {
            await httpContextAccessor!.HttpContext!.SignOutAsync();
            throw new ArgumentException();
        }
    }
}