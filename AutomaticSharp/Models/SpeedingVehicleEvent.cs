using System;
using Newtonsoft.Json;

namespace AutomaticSharp.Models
{
    public class SpeedingVehicleEvent : VehicleEventBase
    {
        [JsonProperty("start_distance_m")]
        public string StartDistanceInMeters { get; set; }

        [JsonProperty("end_distance_m")]
        public string EndDistanceInMeters { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string VelocityMph { get; set; }
    }
}