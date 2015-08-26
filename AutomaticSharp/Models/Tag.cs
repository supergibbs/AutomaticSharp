using Newtonsoft.Json;

namespace AutomaticSharp.Models
{
    public class Tag
    {
        [JsonProperty("tag")]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}