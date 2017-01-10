using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace AspNetCore.Authentication.Session.Sample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSessionAuthentication();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSessionAuthentication();

            app.Map("/login", a => a.Run(async context =>
            {
                var claims = new[] { new Claim(ClaimTypes.Name, "John Doe") };
                await context.Authentication.SignInAsync(SessionAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(new ClaimsIdentity(claims, SessionAuthenticationDefaults.AuthenticationScheme)));
                await context.Response.WriteAsync($"Login successful!");
            }));

            app.Map("/logout", a => a.Run(async context =>
            {
                await context.Authentication.SignOutAsync(SessionAuthenticationDefaults.AuthenticationScheme);
                await context.Response.WriteAsync($"Logout successful!");
            }));

            app.Run(async context =>
            {
                await context.Response.WriteAsync($"Hello {context.User?.Identity?.Name}!");
            });
        }
    }
}
