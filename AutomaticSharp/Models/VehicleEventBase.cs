using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AutomaticSharp.Models
{
    public class VehicleEventBase
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public VehicleEventType EventType { get; set; }
    }
}