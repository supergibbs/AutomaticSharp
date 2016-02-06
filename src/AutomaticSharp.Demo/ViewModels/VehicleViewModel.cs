using System.Collections.Generic;

namespace AutomaticSharp.Demo.ViewModels
{
    public class VehicleViewModel
    {
        public string Id { get; set; }
        public string Vin { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Submodel { get; set; }
        public string DisplayName { get; set; }
        public double FuelLevelPercent { get; set; }

        public IList<TripViewModel> Trips { get; set; }

        public string ComputedName => $@"{Year} {Make} {Model} {Submodel}";
    }
}