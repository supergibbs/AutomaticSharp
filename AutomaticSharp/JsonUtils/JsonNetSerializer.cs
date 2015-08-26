using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace AutomaticSharp.JsonUtils
{
    internal class JsonNetSerializer : ISerializer, IDeserializer
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public JsonNetSerializer()
        {
            ContentType = "application/json";
            _jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new UnderscorePropertyNamesContractResolver(),
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                Converters = new JsonConverter[] { new SecondsTimeSpanConverter() }
            };
        }

        public JsonNetSerializer(JsonSerializerSettings jsonSerializerSettings)
        {
            ContentType = "application/json";
            _jsonSerializerSettings = jsonSerializerSettings;
        }

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, _jsonSerializerSettings);
        }

        public T Deserialize<T>(IRestResponse response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content, _jsonSerializerSettings);
        }

        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }
        public string ContentType { get; set; }
    }
}