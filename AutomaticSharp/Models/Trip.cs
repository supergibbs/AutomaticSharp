using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AutomaticSharp.Models
{
    public class Trip
    {
        /// <summary>
        /// Unique identifier for the trip
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Trip URI
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Driver URI
        /// </summary>
        public string Driver { get; set; }

        /// <summary>
        /// User URI
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Time at start of trip
        /// </summary>
        public DateTime StartedAt { get; set; }

        /// <summary>
        /// Time at end of trip
        /// </summary>
        public DateTime EndedAt { get; set; }

        /// <summary>
        /// Distance of trip in meters
        /// </summary>
        [JsonProperty("distance_m")]
        public double DistanceInMeters { get; set; }

        /// <summary>
        /// Duration of trip in seconds (converted to a TimeSpan)
        /// </summary>
        [JsonProperty("duration_s")]
        public TimeSpan? Duration { get; set; }

        /// <summary>
        /// Vehicle URI
        /// </summary>
        public string Vehicle { get; set; }

        /// <summary>
        /// Lat/Long at start of trip
        /// </summary>
        public Location StartLocation { get; set; }

        /// <summary>
        /// Address at start of trip
        /// </summary>
        public TripSummaryAddressInfo StartAddress { get; set; }

        /// <summary>
        /// Lat/Long at end of trip
        /// </summary>
        public Location EndLocation { get; set; }

        /// <summary>
        /// Address at end of trip
        /// </summary>
        public TripSummaryAddressInfo EndAddress { get; set; }
        
        /// <summary>
        /// Encoded path of trip
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Fuel cost in dollars
        /// </summary>
        public double FuelCostUsd { get; set; }

        /// <summary>
        /// Amount of fuel used in liters
        /// </summary>
        [JsonProperty("fuel_volume_l")]
        public double FuelVolumeInLiters { get; set; }

        /// <summary>
        /// Fuel efficiency in km/liter
        /// </summary>
        [JsonProperty("average_kmpl")]
        public double AverageKmPerLiter { get; set; }

        /// <summary>
        /// Fuel efficiency in km/l per the EPA
        /// </summary>
        [JsonProperty("average_from_epa_kmpl")]
        public double AverageKmPerLiterFromEpa { get; set; }
        
        /// <summary>
        /// Driving score for events
        /// </summary>
        public double? ScoreEvents { get; set; }

        /// <summary>
        /// Driving score for speeding
        /// </summary>
        public double? ScoreSpeeding { get; set; }
        
        /// <summary>
        /// Number of hard brakes
        /// </summary>
        public int HardBrakes { get; set; }

        /// <summary>
        /// Number of hard accelerations
        /// </summary>
        [JsonProperty("hard_accels")]
        public int HardAccelerations { get; set; }

        /// <summary>
        /// Duration of trip spent over 70 mph
        /// </summary>
        [JsonProperty("duration_over_70_s")]
        public TimeSpan? DurationOver70Mph { get; set; }

        /// <summary>
        /// Duration of trip spent over 75 mph
        /// </summary>
        [JsonProperty("duration_over_75_s")]
        public TimeSpan? DurationOver75Mph { get; set; }

        /// <summary>
        /// Duration of trip spent over 80 mph
        /// </summary>
        [JsonProperty("duration_over_80_s")]
        public TimeSpan? DurationOver80Mph { get; set; }

        /// <summary>
        /// Vehicle events
        /// </summary>
        public List<VehicleEventBase> VehicleEvents { get; set; }

        /// <summary>
        /// Timezone at start of trip
        /// </summary>
        public string StartTimezone { get; set; }

        /// <summary>
        /// Timezone at end of trip
        /// </summary>
        public string EndTimezone { get; set; }

        /// <summary>
        /// Fraction of time spent in city
        /// </summary>
        public string CityFraction { get; set; }

        /// <summary>
        /// Fraction of time spent on highway
        /// </summary>
        public string HighwayFraction { get; set; }

        /// <summary>
        /// Fraction of distance spent driving at night
        /// </summary>
        public string NightDrivingFraction { get; set; }

        /// <summary>
        /// Time when engine was idling
        /// </summary>
        [JsonProperty("idling_time_s")]
        public TimeSpan? IdlingTime { get; set; }

        /// <summary>
        /// Trip's tags
        /// </summary>
        public List<string> Tags { get; set; }
    }
}