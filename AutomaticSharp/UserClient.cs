using System.Threading.Tasks;
using AutomaticSharp.Models;
using AutomaticSharp.Requests;

namespace AutomaticSharp
{
    public partial class Client
    {
        const string UserResource = "/user/";

        /// <summary>
        /// Provides the basic account information about a user.
        /// Dependent on scope:user:profile
        /// </summary>
        /// <returns><see cref="User"/></returns>
        public async Task<User> GetUserInfoAsync(string userId = "me")
        {
            return await GetAsync<User>(UserResource + userId + "/");
        }

        /// <summary>
        /// Returns a <see cref="DeviceUserRelationship"/> Object
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<DeviceUserRelationship> GetDeviceAsync(string deviceId, string userId = "me")
        {
            return await GetAsync<DeviceUserRelationship>(UserResource + userId + "/device/" + deviceId + "/");
        }

        /// <summary>
        /// Returns an array of <see cref="DeviceUserRelationship"/> Objects
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AutomaticCollection<DeviceUserRelationship>> GetDevicesAsync(DevicesRequest request = null)
        {
            if (request == null)
                return await GetAsync<AutomaticCollection<DeviceUserRelationship>>(UserResource + "me/device/");

            return await GetAsync<AutomaticCollection<DeviceUserRelationship>>(UserResource + (request.UserId ?? "me") + "/device/", request.CreateParameters());
        }

        public async Task<EmergencyContact> DeleteEmergencyContactAsync(string emergencyContactId, string userId = "me")
        {
            return await DeleteAsync<EmergencyContact>(UserResource + userId + "/emergency-contact/" + emergencyContactId + "/");
        }
    }
}
