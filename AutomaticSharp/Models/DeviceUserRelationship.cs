using Newtonsoft.Json;

namespace AutomaticSharp.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class DeviceUserRelationship
    {
        /// <summary>
        /// Device Identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Device Version
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// Authorization token to allow apps to talk to the Adapter directly
        /// </summary>
        public string DirectAccessToken { get; set; }

        /// <summary>
        /// Application encryption key
        /// </summary>
        public string AppEncryptionKey { get; set; }

        /// <summary>
        /// The vehicle this device is plugged into currently
        /// </summary>
        [JsonProperty("vehicle")]
        public string VehicleId { get; set; }

        /// <summary>
        /// User Device Relationship URI
        /// </summary>
        public string Url { get; set; }
    }
}