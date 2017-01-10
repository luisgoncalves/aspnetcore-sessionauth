using AspNetCore.Authentication.Session;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// Configuration options for <see cref="SessionAuthenticationMiddleware"/>.
    /// </summary>
    public class SessionAuthenticationOptions : AuthenticationOptions
    {
        /// <summary>
        /// Create an instance of the options initialized with the default values.
        /// </summary>
        public SessionAuthenticationOptions()
        {
            AuthenticationScheme = SessionAuthenticationDefaults.AuthenticationScheme;
            AutomaticAuthenticate = true;
            AutomaticChallenge = true;
            LoginPath = SessionAuthenticationDefaults.LoginPath;
            ReturnUrlParameter = SessionAuthenticationDefaults.ReturnUrlParameter;
        }

        /// <summary>
        /// If AutomaticChallenge is true (default), the middleware changes an outgoing 401 Unauthorized status
        /// code into a 302 redirection onto the given login path. The current url which generated the 401 is added
        /// to the LoginPath as a query string parameter named by the ReturnUrlParameter.
        /// </summary>
        public PathString LoginPath { get; set; }

        /// <summary>
        /// The name of the query string parameter which is appended by the middleware when a 401 Unauthorized status
        /// code is changed to a 302 redirect onto the login path.
        /// </summary>
        public string ReturnUrlParameter { get; set; }

        /// <summary>
        /// Used to read/write the authentication ticket for session storage.
        /// </summary>
        public IDataSerializer<AuthenticationTicket> TicketDataSerializer { get; set; }
    }
}
