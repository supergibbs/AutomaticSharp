using System;
using Newtonsoft.Json;

namespace AutomaticSharp.Models
{
    internal class VehicleEvent : VehicleEventBase
    {
        #region Speeding Event

        [JsonProperty("start_distance_m")]
        public string StartDistanceInMeters { get; set; }

        [JsonProperty("end_distance_m")]
        public string EndDistanceInMeters { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string VelocityMph { get; set; }

        #endregion

        #region Hard Event

        [JsonProperty("lat")]
        public string Latitude { get; set; }

        [JsonProperty("lon")]
        public string Longitude { get; set; }

        public DateTime CreatedAt { get; set; }

        public string GForce { get; set; }

        #endregion
    }
}