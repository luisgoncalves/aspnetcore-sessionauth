using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;

namespace AspNetCore.Authentication.Session
{
    /// <summary>
    /// Session-based authentication middleware.
    /// </summary>
    public class SessionAuthenticationMiddleware : AuthenticationMiddleware<SessionAuthenticationOptions>
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="next"></param>
        /// <param name="options"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="encoder"></param>
        public SessionAuthenticationMiddleware(
            RequestDelegate next,
            IOptions<SessionAuthenticationOptions> options,
            ILoggerFactory loggerFactory,
            UrlEncoder encoder)
            : base(next, options, loggerFactory, encoder)
        {
            if (Options.TicketDataSerializer == null)
            {
                Options.TicketDataSerializer = TicketSerializer.Default;
            }
        }

        /// <summary>
        /// Creates a new instance of the authentication handler.
        /// </summary>
        /// <returns>The authentication handler</returns>
        protected override AuthenticationHandler<SessionAuthenticationOptions> CreateHandler() => new SessionAuthenticationHandler();
    }
}
