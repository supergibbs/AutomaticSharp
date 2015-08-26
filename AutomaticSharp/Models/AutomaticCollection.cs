using System.Collections.Generic;
using Newtonsoft.Json;

namespace AutomaticSharp.Models
{
    public class AutomaticCollection<T>
    {
        [JsonProperty("_metadata")]
        public MetaData Metadata { get; set; }

        public List<T> Results { get; set; }
    }
}