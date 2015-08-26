using Newtonsoft.Json;

namespace AutomaticSharp.Models
{
    public class Location
    {
        public string Name { get; set; }
        
        public string DisplayName { get; set; }
        
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }

        public double AccuracyM { get; set; }
    }
}