using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;


namespace Art_Gallery_Management.Security
{
    public class BasicAuthMiddleware : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly BasicAuthSeetings _basicAuthSeetings;

        public BasicAuthMiddleware(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger,
            UrlEncoder encoder, IOptions<BasicAuthSeetings> authSettings) :base(options,logger,encoder)
        {
            _basicAuthSeetings = authSettings.Value;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()

        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return Task.FromResult(AuthenticateResult.Fail("Missing Authorization Header"));
            }
                try
                {
                    var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                    var credentialsByte = Convert.FromBase64String(authHeader.Parameter);
                    var credentials = Encoding.UTF8.GetString(credentialsByte).Split(':');
                    var username = credentials[0];
                    var password = credentials[1];

                    if(username != _basicAuthSeetings.Username || password != _basicAuthSeetings.Password)
                    {
                        return Task.FromResult(AuthenticateResult.Fail("Invalid Username or Password"));

                    }
                    var claims = new[] { new Claim(ClaimTypes.Name, username) };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);

                    return Task.FromResult(AuthenticateResult.Success(ticket));
                }
                catch
                {
                    return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));
                }
            }

        }
    }
