using System;
using System.Threading.Tasks;
using AutomaticSharp.Models;
using AutomaticSharp.Requests;

namespace AutomaticSharp
{
    public partial class Client
    {
        /// <summary>
        /// Get a vehicle
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <returns>Vehicle</returns>
        public async Task<Vehicle> GetVehicleAsync(string vehicleId)
        {
            const string path = "vehicle/";

            if (string.IsNullOrEmpty(vehicleId))
                throw new ArgumentNullException(nameof(vehicleId));

            return await GetAsync<Vehicle>(path + vehicleId + '/');
        }

        /// <summary>
        /// Get list of vehicles
        /// </summary>
        /// <returns>AutomaticCollection&lt;Vehicle&gt;</returns>
        public async Task<AutomaticCollection<Vehicle>> GetVehiclesAsync(VehiclesRequest request = null)
        {
            const string path = "vehicle/";

            if (request == null)
                return await GetAsync<AutomaticCollection<Vehicle>>(path);

            return await GetAsync<AutomaticCollection<Vehicle>>(path, request.CreateParameters());
        }

        /// <summary>
        /// Returns a collection of <see cref="VehicleMilHistory"/> Objects
        /// </summary>
        /// <returns></returns>
        public async Task<AutomaticCollection<VehicleMilHistory>> GetVehiclesMilHistoryAsync(VehiclesMilHistoryRequest request = null)
        {
            const string pathBase = "vehicle/";

            if (request == null)
                return await GetAsync<AutomaticCollection<VehicleMilHistory>>(pathBase + "mil/");

            var path = pathBase;

            if (!string.IsNullOrEmpty(request.VehicleId))
                path += request.VehicleId + "/";

            return await GetAsync<AutomaticCollection<VehicleMilHistory>>(path + "mil/", request.CreateParameters());
        }
    }
}
