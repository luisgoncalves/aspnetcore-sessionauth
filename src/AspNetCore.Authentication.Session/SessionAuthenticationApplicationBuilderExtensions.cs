using AspNetCore.Authentication.Session;
using System;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// Extension methods to add session-based authentication capabilities to an HTTP application pipeline.
    /// </summary>
    public static class SessionAuthenticationApplicationBuilderExtensions
    {
        /// <summary>
        /// Adds the <see cref="SessionAuthenticationMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> to add the middleware to.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseSessionAuthentication(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            app.UseSession();
            app.UseMiddleware<SessionAuthenticationMiddleware>();
            return app;
        }
    }
}
