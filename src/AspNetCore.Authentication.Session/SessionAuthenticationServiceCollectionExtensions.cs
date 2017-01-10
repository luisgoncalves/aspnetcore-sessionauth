using Microsoft.AspNetCore.Builder;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods for setting up session-based authentication services in an <see cref="IServiceCollection" />.
    /// </summary>
    public static class SessionAuthenticationServiceCollectionExtensions
    {
        /// <summary>
        /// Adds services for session-based authentication to the specified <see cref="IServiceCollection" />. This method
        /// should be invoked after adding MVC services to the <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <param name="setupAction">Configuration of <see cref="SessionAuthenticationOptions"/>.</param>
        public static IServiceCollection AddSessionAuthentication(this IServiceCollection services, Action<SessionAuthenticationOptions> setupAction = null)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (setupAction != null)
            {
                services.Configure(setupAction);
            }

            services.AddAuthentication();
            services.AddSession();
            return services;
        }
    }
}
