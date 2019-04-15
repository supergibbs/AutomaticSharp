using System;
using AutomaticSharp.Models;
using Newtonsoft.Json;

namespace AutomaticSharp.JsonUtils
{
    public class VehicleEventConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(VehicleEventBase);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var vehicleEvent = serializer.Deserialize<VehicleEvent>(reader);

            switch (vehicleEvent.EventType)
            {
                case VehicleEventType.Speeding:
                    return new SpeedingVehicleEvent
                    {
                        EventType = VehicleEventType.Speeding,
                        StartDistanceInMeters = vehicleEvent.StartDistanceInMeters,
                        EndDistanceInMeters = vehicleEvent.EndDistanceInMeters,
                        StartTime = vehicleEvent.StartTime,
                        EndTime = vehicleEvent.EndTime,
                        VelocityMph = vehicleEvent.VelocityMph
                    };

                case VehicleEventType.HardAcceleration:
                    return new HardAccelerationVehicleEvent
                    {
                        EventType = VehicleEventType.HardAcceleration,
                        Latitude = vehicleEvent.Latitude,
                        Longitude = vehicleEvent.Longitude,
                        CreatedAt = vehicleEvent.CreatedAt,
                        GForce = vehicleEvent.GForce
                    };

                case VehicleEventType.HardBrake:
                    return new HardBrakeVehicleEvent
                    {
                        EventType = VehicleEventType.HardBrake,
                        Latitude = vehicleEvent.Latitude,
                        Longitude = vehicleEvent.Longitude,
                        CreatedAt = vehicleEvent.CreatedAt,
                        GForce = vehicleEvent.GForce
                    };
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }
    }
}