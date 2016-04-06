using System;
using System.Collections.Generic;

namespace AutomaticSharp.Models
{
    public class Vehicle
    {
        /// <summary>
        /// Vehicle Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Vehicle Identification Number
        /// </summary>
        public string Vin { get; set; }

        /// <summary>
        /// Year
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Make (Honda, Chevy, etc.,)
        /// </summary>
        public string Make { get; set; }

        /// <summary>
        /// Model (Civic, F150, etc.,)
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Submodel (EX, Deluxe, etc.,)
        /// </summary>
        public string Submodel { get; set; }

        /// <summary>
        /// Display name
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Vehicle color, set by the user, in hexidecimal RGB
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Vehicle URI
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Created at
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Updated at
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// The device plugged into this vehicle currently
        /// </summary>
        public string Device { get; set; }

        /// <summary>
        /// Fuel Grade
        /// </summary>
        public string FuelGrade { get; set; }

        /// <summary>
        /// Amount of fuel as percentage of total capacity
        /// </summary>
        public double FuelLevelPercent { get; set; }

        /// <summary>
        /// Battery voltage
        /// </summary>
        public double BatteryVoltage { get; set; }

        /// <summary>
        /// Last known location
        /// </summary>
        public double LastestLocation { get; set; }

        /// <summary>
        /// Currently active MILs	
        /// </summary>
        public List<VehicleMil> ActiveDtcs { get; set; }
    }
}