using System;
using System.Threading.Tasks;
using AutomaticSharp.Models;
using AutomaticSharp.Requests;

namespace AutomaticSharp
{
    public partial class Client
    {
        const string TripsResource = "/trip/";

        /// <summary>
        /// Gets trip
        /// </summary>
        /// <param name="tripId"></param>
        /// <returns></returns>
        public async Task<Trip> GetTripAsync(string tripId)
        {

            if (string.IsNullOrEmpty(tripId))
                throw new ArgumentNullException(nameof(tripId));

            return await GetAsync<Trip>(TripsResource + tripId + "/");
        }

        /// <summary>
        /// Gets one or more trips with paging
        /// </summary>
        /// <param name="tripsRequest"></param>
        /// <returns></returns>
        public async Task<AutomaticCollection<Trip>> GetTripsAsync(TripsRequest tripsRequest)
        {
            if (tripsRequest == null)
                throw new ArgumentNullException(nameof(tripsRequest));

            return await GetAsync<AutomaticCollection<Trip>>(TripsResource, tripsRequest.CreateParameters());
        }
    }
}
