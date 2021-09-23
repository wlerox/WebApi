
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using UserInfo.Business.Abstract;

namespace UserInfo.API
{
    public class AuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        readonly IAuthService _authService;
        public AuthHandler(
            IAuthService authService,
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock
            ): base(options,logger,encoder,clock)
        {
            _authService = authService;
        }
        protected override  Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            Response.Headers["WWW-Authenticate"] = "Basic";
            return base.HandleChallengeAsync(properties);
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string username = null;
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter)).Split(":");
                username = credentials.FirstOrDefault();
                var password = credentials.LastOrDefault();
                if (!_authService.Login(username, password)) {
                    throw new ArgumentException("Invalid Username or Password");
                } ;
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail(ex.Message);
            }
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,username)
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal,Scheme.Name);
            return AuthenticateResult.Success(ticket);
            //throw new NotImplementedException();
        }
    }
}
