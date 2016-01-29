using System.Threading.Tasks;
using AutomaticSharp.Models;
using AutomaticSharp.Requests;

namespace AutomaticSharp
{
    public partial class Client
    {
        /// <summary>
        /// Provides the basic account information about a user.
        /// Dependent on scope:user:profile
        /// </summary>
        /// <returns><see cref="User"/></returns>
        public async Task<AutomaticCollection<User>> GetUserInfoAsync(string userId = "me")
        {
            const string path = "user/";

            return await GetAsync<AutomaticCollection<User>>(path + userId + "/");
        }

        /// <summary>
        /// Returns a <see cref="DeviceUserRelationship"/> Object
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<DeviceUserRelationship> GetDeviceAsync(string deviceId, string userId = "me")
        {
            const string path = "user/";

            return await GetAsync<DeviceUserRelationship>(path + userId + "/device/" + deviceId + "/");
        }

        /// <summary>
        /// Returns an array of <see cref="DeviceUserRelationship"/> Objects
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AutomaticCollection<DeviceUserRelationship>> GetDevicesAsync(DevicesRequest request=null)
        {
            const string path = "user/";

            if(request == null)
                return await GetAsync<AutomaticCollection<DeviceUserRelationship>>(path + "me/device/");

            return await GetAsync<AutomaticCollection<DeviceUserRelationship>>(path + (request.UserId ?? "me") + "/device/", request.CreateParameters());
        }

        public async Task DeleteEmergencyContactAsync(string emergencyContactId, string userId = "me")
        {
            const string path = "user/";

            await DeleteAsync(path + userId + "/emergency-contact/" + emergencyContactId + "/");
        }
    }
}
