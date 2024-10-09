using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public BasicAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock)
        : base(options, logger, encoder, clock)
    {
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.ContainsKey("Authorization"))
            return AuthenticateResult.Fail("Missing Authorization Header");

        try
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);

            if (authHeaderVal.Scheme.Equals("Basic", StringComparison.OrdinalIgnoreCase))
            {
                var credentials = Encoding.UTF8
                    .GetString(Convert.FromBase64String(authHeaderVal.Parameter))
                    .Split(':', 2);

                var username = credentials[0];
                var password = credentials[1];

                // Here, validate the username and password. This is just an example:
                if (username == "testuser" && password == "password123")
                {
                    var claims = new[] {
                        new Claim(ClaimTypes.NameIdentifier, username),
                        new Claim(ClaimTypes.Name, username),
                    };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);

                    return AuthenticateResult.Success(ticket);
                }
            }

            return AuthenticateResult.Fail("Invalid Authorization Header");
        }
        catch
        {
            return AuthenticateResult.Fail("Invalid Authorization Header");
        }
    }
}
