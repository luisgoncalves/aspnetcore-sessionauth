using Microsoft.AspNetCore.Http;

namespace AspNetCore.Authentication.Session
{
    /// <summary>
    /// Default values related to session-based authentication middleware.
    /// </summary>
    public static class SessionAuthenticationDefaults
    {
        /// <summary>
        /// The default value used for SessionAuthenticationOptions.AuthenticationScheme.
        /// </summary>
        public static readonly string AuthenticationScheme = "Session";

        /// <summary>
        /// The default value used for SessionAuthenticationOptions.LoginPath.
        /// </summary>
        public static readonly PathString LoginPath = new PathString("/Account/Login");

        /// <summary>
        /// The default value for SessionAuthenticationOptions.ReturnUrlParameter.
        /// </summary>
        public static readonly string ReturnUrlParameter = "ReturnUrl";
    }
}
