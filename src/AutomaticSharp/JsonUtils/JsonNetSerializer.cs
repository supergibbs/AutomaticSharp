using Newtonsoft.Json;

namespace AutomaticSharp.JsonUtils
{

#if NET40 || NET45
    using RestSharp;
    using RestSharp.Deserializers;
    using RestSharp.Serializers;

    internal partial class JsonNetSerializer : ISerializer, IDeserializer
    {
        public T Deserialize<T>(IRestResponse response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content, _jsonSerializerSettings);
        }
    }
#endif

    internal partial class JsonNetSerializer
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

        public T Deserialize<T>(string jsonContent)
        {
            return JsonConvert.DeserializeObject<T>(jsonContent, _jsonSerializerSettings);
        }

        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }
        public string ContentType { get; set; }
    }
}