using System.Net;
using System.Web;
using AutomaticSharp.Models;
using RestSharp;

namespace AutomaticSharp
{
    public partial class Client
    {
        /// <summary>
        /// Get User Information
        /// Dependent on scope:user:profile
        /// </summary>
        /// <param name="authToken"></param>
        /// <returns>AutomaticUser</returns>
        public User GetUserInfo(string authToken)
        {
            var restRequest = CreateRestRequest("user/me/", authToken);

            var restResponse = _restClient.Execute<User>(restRequest);

            if (restResponse.ResponseStatus == ResponseStatus.Completed && restResponse.StatusCode == HttpStatusCode.OK)
                return restResponse.Data;

            throw new HttpException((int)restResponse.StatusCode, restResponse.ErrorMessage, restResponse.ErrorException);
        }
    }
}
