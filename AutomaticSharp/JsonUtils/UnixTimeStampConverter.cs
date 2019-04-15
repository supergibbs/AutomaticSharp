using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AutomaticSharp.JsonUtils
{
    public class UnixTimeStampConverter : DateTimeConverterBase
    {
        private readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (!long.TryParse(reader.Value.ToString(), out long unixValue))
                return null;

            return _epoch.AddMilliseconds(unixValue);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            long? jsonValue = null;

            if (value != null)
                jsonValue = (long)((DateTime)value).Subtract(_epoch).TotalMilliseconds;

            writer.WriteValue(jsonValue);
        }
    }
}