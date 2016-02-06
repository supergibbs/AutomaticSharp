using System.Collections.Generic;

namespace AutomaticSharp.Demo.ViewModels
{
    public class TripViewModel
    {
        public string Id { get; set; }

        public string StartedAt { get; set; }
        public double StartLocationLatitude { get; set; }
        public double StartLocationLongitude { get; set; }
        public string StartLocationName { get; set; }
        
        public string EndedAt { get; set; }
        public double EndLocationLatitude { get; set; }
        public double EndLocationLongitude { get; set; }
        public string EndLocationName { get; set; }

        public string Path { get; set; }
        public double DistanceInMeters { get; set; }

        public string Duration { get; set; }

        public double FuelCostUsd { get; set; }

        public double ScoreEvents { get; set; }

        public IList<string> Tags { get; set; }
    }
}