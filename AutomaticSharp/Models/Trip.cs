using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AutomaticSharp.Models
{
    public class Trip
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string User { get; set; }
        public string Vehicle { get; set; }

        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public string StartTimezone { get; set; }
        public string EndTimezone { get; set; }

        [JsonProperty("duration_s")]
        public TimeSpan? Duration { get; set; }

        [JsonProperty("idling_time_s")]
        public TimeSpan? IdlingTime { get; set; }

        public Location StartLocation { get; set; }
        public Address StartAddress { get; set; }

        public Location EndLocation { get; set; }
        public Address EndAddress { get; set; }

        public string Path { get; set; }

        [JsonProperty("distance_m")]
        public double DistanceInMeters { get; set; }

        public double ScoreEvents { get; set; }
        public double ScoreSpeeding { get; set; }

        [JsonProperty("hard_accels")]
        public int HardAccelerations { get; set; }

        public int HardBrakes { get; set; }

        [JsonProperty("duration_over_80_s")]
        public TimeSpan? DurationOver80Mph { get; set; }

        [JsonProperty("duration_over_75_s")]
        public TimeSpan? DurationOver75Mph { get; set; }

        [JsonProperty("duration_over_70_s")]
        public TimeSpan? DurationOver70Mph { get; set; }

        public double FuelCostUsd { get; set; }

        [JsonProperty("fuel_volume_l")]
        public double FuelVolumeInLiters { get; set; }

        [JsonProperty("average_kmpl")]
        public double AverageKmPerLiter { get; set; }

        public List<VehicleEventBase> VehicleEvents { get; set; }

        public List<string> Tags { get; set; }
    }
}