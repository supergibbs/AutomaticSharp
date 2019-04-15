using System.Collections.Generic;
using Newtonsoft.Json;

namespace AutomaticSharp.Models
{
    public class AutomaticCollection<T>
    {
        /// <summary>
        /// Metadata
        /// </summary>
        [JsonProperty("_metadata")]
        public MetaData Metadata { get; set; }

        /// <summary>
        /// Results
        /// </summary>
        public List<T> Results { get; set; }
    }
}