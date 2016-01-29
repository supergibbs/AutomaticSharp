using System;
using Newtonsoft.Json;

namespace AutomaticSharp.JsonUtils
{
    public class SecondsTimeSpanConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TimeSpan) || objectType == typeof(TimeSpan?);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            double seconds;

            if (!double.TryParse(reader.Value.ToString(), out seconds))
                return null;

            return TimeSpan.FromSeconds(seconds);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            double? jsonValue = null;

            if (value != null)
                jsonValue = ((TimeSpan)value).TotalSeconds;

            writer.WriteValue(jsonValue);
        }
    }
}