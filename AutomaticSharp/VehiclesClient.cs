using System.Net;
using System.Web;
using AutomaticSharp.Models;
using RestSharp;

namespace AutomaticSharp
{
    public partial class Client
    {
        /// <summary>
        /// Get list of vehicles
        /// </summary>
        /// <param name="authToken"></param>
        /// <param name="vehicleId"></param>
        /// <returns>Vehicle</returns>
        public Vehicle GetVehicle(string authToken, string vehicleId)
        {
            var restRequest = CreateRestRequest("vehicle/" + vehicleId, authToken);

            var restResponse = _restClient.Execute<Vehicle>(restRequest);

            if (restResponse.ResponseStatus == ResponseStatus.Completed && restResponse.StatusCode == HttpStatusCode.OK)
                return restResponse.Data;

            throw new HttpException((int)restResponse.StatusCode, restResponse.ErrorMessage, restResponse.ErrorException);
        }

        /// <summary>
        /// Get list of vehicles
        /// </summary>
        /// <param name="authToken"></param>
        /// <returns>AutomaticCollection&lt;Vehicle&gt;</returns>
        public AutomaticCollection<Vehicle> GetVehicles(string authToken)
        {
            var restRequest = CreateRestRequest("vehicle/", authToken);

            var restResponse = _restClient.Execute<AutomaticCollection<Vehicle>>(restRequest);

            if (restResponse.ResponseStatus == ResponseStatus.Completed && restResponse.StatusCode == HttpStatusCode.OK)
                return restResponse.Data;

            throw new HttpException((int)restResponse.StatusCode, restResponse.ErrorMessage, restResponse.ErrorException);
        }
    }
}
