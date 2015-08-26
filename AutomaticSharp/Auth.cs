using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using AutomaticSharp.JsonUtils;
using AutomaticSharp.Models;
using RestSharp;

namespace AutomaticSharp
{
    /// <summary>
    /// OAuth2 client for Automatic REST API
    /// https://developer.automatic.com/api-reference/#authentication
    /// </summary>
    public class Auth
    {
        public const string OAuthUrl = "https://accounts.automatic.com";
        private readonly RestClient _client;

        public Auth()
        {
            _client = new RestClient { BaseUrl = new Uri(OAuthUrl) };
        }

        /// <summary>
        /// Create Automatic authorize URL
        /// </summary>
        /// <param name="account">Automatic ApiAccount object</param>
        /// <param name="scopes">Enumeration of Scope enums you need</param>
        /// <returns>An Automatic authorize URL</returns>
        public static string CreateLoginUrl(Account account, params Scope[] scopes)
        {
            return CreateLoginUrl(account.ClientId, null, scopes);
        }

        /// <summary>
        /// Create Automatic authorize URL
        /// </summary>
        /// <param name="account">Automatic ApiAccount object</param>
        /// <param name="state">String used to protect against cross-site request forgery attacks</param>
        /// <param name="scopes">Enumeration of Scope enums you need</param>
        /// <returns>An Automatic authorize URL</returns>
        public static string CreateLoginUrl(Account account, string state, params Scope[] scopes)
        {
            return CreateLoginUrl(account.ClientId, state, scopes);
        }

        /// <summary>
        /// Create Automatic authorize URL
        /// </summary>
        /// <param name="clientId">Automatic API Client Id</param>
        /// <param name="scopes">Enumeration of Scope enums you need</param>
        /// <returns>An Automatic authorize URL</returns>
        public static string CreateLoginUrl(string clientId, params Scope[] scopes)
        {
            return CreateLoginUrl(clientId, null, scopes);
        }

        /// <summary>
        /// Create Automatic authorize URL
        /// </summary>
        /// <param name="clientId">Automatic API Client Id</param>
        /// <param name="state">String used to protect against cross-site request forgery attacks</param>
        /// <param name="scopes">Enumeration of Scope enums you need</param>
        /// <returns>An Automatic authorize URL</returns>
        public static string CreateLoginUrl(string clientId, string state, params Scope[] scopes)
        {
            var queryParameters = new Dictionary<string, string>
                {
                    {"client_id", clientId},
                    {"response_type", "code"}
                };

            if (scopes != null)
                queryParameters.Add("scope", String.Join(" ", scopes.Select(GetScopeDescription)));

            if (state != null)
                queryParameters.Add("state", state);

            var automaticUrl = new UriBuilder(OAuthUrl)
            {
                Path = "oauth/authorize",
                Query = string.Join("&", queryParameters.Select(q => q.Key + '=' + q.Value).ToArray())
            };

            return automaticUrl.ToString();
        }

        /// <summary>
        /// Get an access token 
        /// </summary>
        /// <param name="account">client id and secret</param>
        /// <param name="code">users code</param>
        /// <returns>an ApiAccessToken</returns>
        public ApiAccessToken GetAccessToken(Account account, string code)
        {
            var restRequest = CreateRestRequest(account);

            restRequest.AddParameter("code", code);
            restRequest.AddParameter("grant_type", "authorization_code");

            var restResponse = _client.Execute<ApiAccessToken>(restRequest);

            if (restResponse.ResponseStatus == ResponseStatus.Completed && restResponse.StatusCode == HttpStatusCode.OK)
                return restResponse.Data;

            throw new Exception(restResponse.ErrorMessage, restResponse.ErrorException);
        }

        public ApiAccessToken RefreshAccessToken(Account account, ApiAccessToken expiredToken)
        {
            var restRequest = CreateRestRequest(account);

            restRequest.AddParameter("refresh_token", expiredToken.RefreshToken);
            restRequest.AddParameter("grant_type", "refresh_token");

            var restResponse = _client.Execute<ApiAccessToken>(restRequest);

            if (restResponse.ResponseStatus == ResponseStatus.Completed && restResponse.StatusCode == HttpStatusCode.OK)
                return restResponse.Data;

            throw new Exception(restResponse.ErrorMessage, restResponse.ErrorException);
        }

        private static RestRequest CreateRestRequest(Account account)
        {
            var restRequest = new RestRequest
            {
                Resource = "oauth/access_token",
                Method = Method.POST,
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonNetSerializer()
            };

            restRequest.AddParameter("client_id", account.ClientId);
            restRequest.AddParameter("client_secret", account.ClientSecret);

            return restRequest;
        }

        private static string GetScopeDescription(Scope value)
        {
            var fi = typeof(Scope).GetField(value.ToString());

            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}
