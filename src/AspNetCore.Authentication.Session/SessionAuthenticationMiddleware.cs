using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;

namespace AspNetCore.Authentication.Session
{
    public class SessionAuthenticationMiddleware : AuthenticationMiddleware<SessionAuthenticationOptions>
    {
        public SessionAuthenticationMiddleware(
            RequestDelegate next,
            IOptions<SessionAuthenticationOptions> options,
            ILoggerFactory loggerFactory,
            UrlEncoder encoder)
            : base(next, options, loggerFactory, encoder)
        {
        }

        protected override AuthenticationHandler<SessionAuthenticationOptions> CreateHandler()
        {
            throw new NotImplementedException();
        }
    }
}
