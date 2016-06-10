using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json.Linq;

namespace AutomaticSharp.Auth
{
    internal class AutomaticHandler : OAuthHandler<AutomaticOptions>
    {
        public AutomaticHandler(HttpClient httpClient) : base(httpClient) { }

        protected override async Task<AuthenticationTicket> CreateTicketAsync(ClaimsIdentity identity, AuthenticationProperties properties, OAuthTokenResponse tokens)
        {
            // Get the Automatic user
            var request = new HttpRequestMessage(HttpMethod.Get, Options.UserInformationEndpoint);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokens.AccessToken);

            var response = await Backchannel.SendAsync(request, Context.RequestAborted);
            response.EnsureSuccessStatusCode();

            var payload = JObject.Parse(await response.Content.ReadAsStringAsync());

            var ticket = new AuthenticationTicket(new ClaimsPrincipal(identity), properties, Options.AuthenticationScheme);
            var context = new OAuthCreatingTicketContext(ticket, Context, Options, Backchannel, tokens, payload);

            var identifier = AutomaticHelper.GetId(payload);
            if(!string.IsNullOrEmpty(identifier))
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, identifier, ClaimValueTypes.String, Options.ClaimsIssuer));

            var firstName = AutomaticHelper.GetFirstName(payload);
            if(!string.IsNullOrEmpty(firstName))
                identity.AddClaim(new Claim(ClaimTypes.GivenName, firstName, ClaimValueTypes.String, Options.ClaimsIssuer));

            var lastName = AutomaticHelper.GetLastName(payload);
            if(!string.IsNullOrEmpty(lastName))
                identity.AddClaim(new Claim(ClaimTypes.Surname, lastName, ClaimValueTypes.String, Options.ClaimsIssuer));

            var userName = AutomaticHelper.GetUserName(payload);
            if(!string.IsNullOrEmpty(userName))
                identity.AddClaim(new Claim(ClaimTypes.Name, userName, ClaimValueTypes.String, Options.ClaimsIssuer));

            var email = AutomaticHelper.GetEmail(payload);
            if(!string.IsNullOrEmpty(email))
                identity.AddClaim(new Claim(ClaimTypes.Email, email, ClaimValueTypes.String, Options.ClaimsIssuer));

            var url = AutomaticHelper.GetUrl(payload);
            if(!string.IsNullOrEmpty(url))
                identity.AddClaim(new Claim(ClaimTypes.Uri, url, ClaimValueTypes.String, Options.ClaimsIssuer));

            await Options.Events.CreatingTicket(context);

            return context.Ticket;
        }

        protected override string BuildChallengeUrl(AuthenticationProperties properties, string redirectUri)
        {
            var scopes = FormatScope();

            var queryStrings = new Dictionary<string, string>
            {
                {"client_id", Options.ClientId},
                {"response_type", "code"},
                {"scope", scopes}
            };


            var state = Options.StateDataFormat.Protect(properties);
            queryStrings.Add("state", state);

            var authorizationEndpoint = QueryHelpers.AddQueryString(Options.AuthorizationEndpoint, queryStrings);
            return authorizationEndpoint;
        }
    }
}