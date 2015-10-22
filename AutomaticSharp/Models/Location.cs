using Newtonsoft.Json;

namespace AutomaticSharp.Models
{
    public class Location
    {
        ///// <summary>
        ///// Name
        ///// </summary>
        //public string Name { get; set; }
        
        ///// <summary>
        ///// Display name
        ///// </summary>
        //public string DisplayName { get; set; }
        
        /// <summary>
        /// Latitude
        /// </summary>
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        [JsonProperty("lon")]
        public double Longitude { get; set; }

        /// <summary>
        /// Accuracy in meters
        /// </summary>
        public double AccuracyM { get; set; }
    }
}