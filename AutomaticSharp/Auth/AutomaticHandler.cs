using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Authentication;
using Microsoft.AspNet.Authentication.OAuth;
using Microsoft.AspNet.Http.Authentication;
using Newtonsoft.Json.Linq;

namespace AutomaticSharp.Auth
{
    internal class AutomaticHandler : OAuthHandler<AutomaticOptions>
    {
        public AutomaticHandler(HttpClient backchannel) : base(backchannel)
        {
        }

        protected override async Task<AuthenticationTicket> CreateTicketAsync(ClaimsIdentity identity, AuthenticationProperties properties, OAuthTokenResponse tokens)
        {
            // Get the Automatic user
            var request = new HttpRequestMessage(HttpMethod.Get, Options.UserInformationEndpoint);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokens.AccessToken);

            var response = await Backchannel.SendAsync(request, Context.RequestAborted);
            response.EnsureSuccessStatusCode();

            var payload = JObject.Parse(await response.Content.ReadAsStringAsync());

            var context = new OAuthCreatingTicketContext(Context, Options, Backchannel, tokens, payload)
            {
                Properties = properties,
                Principal = new ClaimsPrincipal(identity)
            };

            var identifier = AutomaticHelper.GetId(payload);
            if (!string.IsNullOrEmpty(identifier))
            {
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, identifier, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            var givenName = AutomaticHelper.GetFirstName(payload);
            if (!string.IsNullOrEmpty(givenName))
            {
                identity.AddClaim(new Claim(ClaimTypes.GivenName, givenName, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            var familyName = AutomaticHelper.GetLastName(payload);
            if (!string.IsNullOrEmpty(familyName))
            {
                identity.AddClaim(new Claim(ClaimTypes.Surname, familyName, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            var name = AutomaticHelper.GetUserName(payload);
            if (!string.IsNullOrEmpty(name))
            {
                identity.AddClaim(new Claim(ClaimTypes.Name, name, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            var email = AutomaticHelper.GetEmail(payload);
            if (!string.IsNullOrEmpty(email))
            {
                identity.AddClaim(new Claim(ClaimTypes.Email, email, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            var profile = AutomaticHelper.GetUrl(payload);
            if (!string.IsNullOrEmpty(profile))
            {
                identity.AddClaim(new Claim(ClaimTypes.Uri, profile, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            await Options.Events.CreatingTicket(context);

            return new AuthenticationTicket(context.Principal, context.Properties, context.Options.AuthenticationScheme);
        }

        protected override string BuildChallengeUrl(AuthenticationProperties properties, string redirectUri)
        {
            var scopes = FormatScope();

            var queryParameters = new Dictionary<string, string>
            {
                {"client_id", Options.ClientId},
                {"response_type", "code"}
            };

            if (scopes != null)
                queryParameters.Add("scope", scopes);

            var state = Options.StateDataFormat.Protect(properties);
            queryParameters.Add("state", state);

            var automaticUrl = new UriBuilder(Options.AuthorizationEndpoint)
            {
                Query = string.Join("&", queryParameters.Select(q => q.Key + '=' + q.Value).ToArray())
            };

            return automaticUrl.ToString();
        }
    }
}