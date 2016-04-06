using System;

namespace AutomaticSharp.Models
{
    public class VehicleMil
    {
        /// <summary>
        /// Malfunction indicator lamp code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Indicates if the light is on	
        /// </summary>
        public bool On { get; set; }

        /// <summary>
        /// Event time
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Human readable description of the MIL
        /// </summary>
        public string Description { get; set; }
    }
}