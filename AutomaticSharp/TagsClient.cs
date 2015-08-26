using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using AutomaticSharp.Models;
using RestSharp;

namespace AutomaticSharp
{
    public partial class Client
    {
        /// <summary>
        /// Provides a listing of all tags on a user account
        /// </summary>
        /// <param name="authToken">Valid authentication token</param>
        /// <param name="page">Specifies the page of paginated results to return.</param>
        /// <param name="limit">Number of results per page</param>
        /// <param name="startsWith">Tag prefix filter. Multiple values will be searched as an OR</param>
        /// <returns></returns>
        public List<Tag> GetTags(string authToken, int page = 1, int limit = 10, params string[] startsWith)
        {
            var restRequest = CreateRestRequest("tag/", authToken);

            if (limit < 1 || limit > 250)
                throw new ArgumentOutOfRangeException("limit", limit, "limit must be between 1 and 250");

            if (page < 1)
                throw new ArgumentOutOfRangeException("page", page, "page must greater than 0");

            if (page != 1)
                restRequest.AddParameter("page", page);

            if (limit != 10)
                restRequest.AddParameter("limit", limit);

            if (startsWith != null && startsWith.Length > 0)
                restRequest.AddParameter("tag__istartswith", String.Join(",", startsWith));

            var restResponse = _restClient.Execute<List<Tag>>(restRequest);

            if (restResponse.ResponseStatus == ResponseStatus.Completed && restResponse.StatusCode == HttpStatusCode.OK)
                return restResponse.Data;

            throw new HttpException((int)restResponse.StatusCode, restResponse.ErrorMessage, restResponse.ErrorException);
        }
    }
}
