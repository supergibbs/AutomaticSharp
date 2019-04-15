using System;
using System.Collections.Generic;
using AutomaticSharp.JsonUtils;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;

namespace AutomaticSharp
{
    /// <summary>
    /// An Automatic API Client
    /// </summary>
    public partial class Client
    {
        /// <summary>
        /// The Automatic API URL
        /// </summary>
        public const string BaseApiUrl = "https://api.automatic.com";

        private readonly HttpClient _httpClient;

        /// <summary>
        /// Creates a new Automatic Client using the standard Automatic API URL
        /// </summary>
        /// <param name="authToken">Bearer token</param>
        public Client(string authToken) : this(authToken, BaseApiUrl) { }

        /// <summary>
        /// Creates a new Automatic Client with a custom Automatic API URL (for debugging/testing)
        /// </summary>
        /// <param name="authToken">Bearer token</param>
        /// <param name="apiUrl">Automatic API URL</param>
        public Client(string authToken, string apiUrl)
        {
            if (string.IsNullOrWhiteSpace(authToken))
                throw new ArgumentNullException(nameof(authToken), "Bearer token is required");

            if (string.IsNullOrWhiteSpace(apiUrl))
                throw new ArgumentNullException(nameof(apiUrl), "API URI is required");

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(apiUrl),
                DefaultRequestHeaders =
                {
                    Authorization = new AuthenticationHeaderValue("Bearer", authToken),
                    Accept = {
                        MediaTypeWithQualityHeaderValue.Parse("text/json"),
                        MediaTypeWithQualityHeaderValue.Parse("application/json")
                    }
                }
            };
        }

        /// <summary>
        /// Helper method for making a REST GET request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private async Task<T> GetAsync<T>(string resource, Dictionary<string, string> parameters = null)
        {
            var path = resource;

            if (parameters != null && parameters.Count > 0)
            {
                path += "?";
                foreach(var item in parameters)
                {
                    path += $"{item.Key}={Uri.EscapeDataString(item.Value)}&";
                }
            }

            var request = new HttpRequestMessage(HttpMethod.Get, path);
            var response = (await _httpClient.SendAsync(request));

            //Thanks to https://stackoverflow.com/a/28671822/40887
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                // Authorization header has been set, but the server reports that it is missing.
                // It was probably stripped out due to a redirect.
                var finalRequestUri = response.RequestMessage.RequestUri; // contains the final location after following the redirect.

                if (finalRequestUri.PathAndQuery != path) // detect that a redirect actually did occur.
                {
                    if (finalRequestUri.Host == _httpClient.BaseAddress.Host) // check that we can trust the host we were redirected to.
                    {
                        response = _httpClient.GetAsync(finalRequestUri).Result; // Reissue the request. The DefaultRequestHeaders configured on the client will be used, so we don't have to set them again.
                    }
                }
            }

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return new JsonNetSerializer().Deserialize<T>(content);
        }

        private async Task<T> DeleteAsync<T>(string path)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, path);
            var response = await _httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            return new JsonNetSerializer().Deserialize<T>(content);
        }
    }
}
