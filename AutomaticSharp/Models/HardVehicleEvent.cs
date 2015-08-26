using System;
using Newtonsoft.Json;

namespace AutomaticSharp.Models
{
    public abstract class HardVehicleEvent : VehicleEventBase
    {
        [JsonProperty("lat")]
        public string Latitude { get; set; }

        [JsonProperty("lon")]
        public string Longitude { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public string GForce { get; set; }
    }
}