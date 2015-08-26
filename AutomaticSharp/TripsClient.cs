using System.Net;
using System.Web;
using AutomaticSharp.Models;
using RestSharp;

namespace AutomaticSharp
{
    public partial class Client
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="authToken"></param>
        /// <param name="vehicleId"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public AutomaticCollection<Trip> GetTrips(string authToken, string vehicleId = null, int page = 1, int limit = 10)
        {
            var restRequest = CreateRestRequest("trip/", authToken);

            if (!string.IsNullOrWhiteSpace(vehicleId))
                restRequest.AddParameter("vehicle", vehicleId); //Get only trips for this vehicle

            if (page != 1)
                restRequest.AddParameter("page", page);

            if (limit != 10)
                restRequest.AddParameter("limit", limit);

            var restResponse = _restClient.Execute<AutomaticCollection<Trip>>(restRequest);

            if (restResponse.ResponseStatus == ResponseStatus.Completed && restResponse.StatusCode == HttpStatusCode.OK)
                return restResponse.Data;

            throw new HttpException((int)restResponse.StatusCode, restResponse.ErrorMessage, restResponse.ErrorException);
        }
    }
}
