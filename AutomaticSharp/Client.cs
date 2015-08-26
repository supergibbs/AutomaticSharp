using System;
using AutomaticSharp.JsonUtils;
using RestSharp;

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

        private readonly RestClient _restClient;

        /// <summary>
        /// Creates a new Automatic Client using the standard Automatic API URL
        /// </summary>
        public Client() : this(BaseApiUrl) { }

        /// <summary>
        /// Creates a new Automatic Client with a custom Automatic API URL (for debugging/testing)
        /// </summary>
        /// <param name="apiUrl">Automatic API URL</param>
        public Client(string apiUrl)
        {
            _restClient = new RestClient { BaseUrl = new Uri(apiUrl) };
            _restClient.AddHandler("application/json", new JsonNetSerializer());
            _restClient.AddHandler("text/json", new JsonNetSerializer());
        }

        /// <summary>
        /// Helper method for setting up a REST request
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="authToken"></param>
        /// <returns></returns>
        private static RestRequest CreateRestRequest(string resource, string authToken)
        {
            if (string.IsNullOrWhiteSpace(authToken))
                throw new UnauthorizedAccessException("Missing or invalid auth token");

            var restRequest = new RestRequest
            {
                Resource = resource,
                Method = Method.GET,
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonNetSerializer()
            };

            restRequest.AddHeader("Authorization", "Bearer " + authToken);

            return restRequest;
        }
    }
}