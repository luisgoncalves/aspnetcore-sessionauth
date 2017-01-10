using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features.Authentication;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Http;

namespace AspNetCore.Authentication.Session
{
    internal class SessionAuthenticationHandler : AuthenticationHandler<SessionAuthenticationOptions>
    {
        private static readonly string PrincipalSessionKey = typeof(SessionAuthenticationHandler).FullName + ".Principal";

        protected override Task<AuthenticateResult> HandleAuthenticateAsync() => Task.FromResult(HandleAuthenticate());

        private AuthenticateResult HandleAuthenticate()
        {
            byte[] ticketBytes;
            if (!Context.Session.TryGetValue(PrincipalSessionKey, out ticketBytes))
            {
                return AuthenticateResult.Skip();
            }

            var ticket = Options.TicketDataSerializer.Deserialize(ticketBytes);
            if (ticket == null)
            {
                return AuthenticateResult.Fail("Deserialize ticket failed");
            }

            return AuthenticateResult.Success(ticket);
        }

        protected override Task HandleSignInAsync(SignInContext context)
        {
            var ticket = new AuthenticationTicket(
                context.Principal,
                new AuthenticationProperties(context.Properties),
                context.AuthenticationScheme);

            var ticketBytes = Options.TicketDataSerializer.Serialize(ticket);
            Context.Session.Set(PrincipalSessionKey, ticketBytes);
            return Task.CompletedTask;
        }

        protected override Task HandleSignOutAsync(SignOutContext context)
        {
            Context.Session.Remove(PrincipalSessionKey);
            return Task.CompletedTask;
        }

        protected override Task<bool> HandleUnauthorizedAsync(ChallengeContext context)
        {
            var properties = new AuthenticationProperties(context.Properties);
            var redirectUri = properties.RedirectUri;
            if (string.IsNullOrEmpty(redirectUri))
            {
                redirectUri = OriginalPathBase + Request.Path + Request.QueryString;
            }

            var loginUri = Options.LoginPath + QueryString.Create(Options.ReturnUrlParameter, redirectUri);
            Response.Redirect(BuildRedirectUri(loginUri));
            return Task.FromResult(true);
        }
    }
}
