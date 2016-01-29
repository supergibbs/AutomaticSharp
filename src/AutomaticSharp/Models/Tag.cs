using Newtonsoft.Json;

namespace AutomaticSharp.Models
{
    public class Tag
    {
        /// <summary>
        /// Tag Name
        /// </summary>
        [JsonProperty("tag")]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}