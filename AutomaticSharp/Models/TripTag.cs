using System;

namespace AutomaticSharp.Models
{
    public class TripTag : Tag
    {
        /// <summary>
        /// Date when trip was tagged
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}