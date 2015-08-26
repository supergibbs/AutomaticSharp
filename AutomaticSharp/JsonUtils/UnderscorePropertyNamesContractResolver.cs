using System.Text.RegularExpressions;
using Newtonsoft.Json.Serialization;

namespace AutomaticSharp.JsonUtils
{
    public class UnderscorePropertyNamesContractResolver : DefaultContractResolver
    {
        private readonly Regex _regex = new Regex("(?!(^[A-Z]))([A-Z])");

        protected override string ResolvePropertyName(string propertyName)
        {
            return _regex.Replace(propertyName, "_$2").ToLower();
        }
    }
}