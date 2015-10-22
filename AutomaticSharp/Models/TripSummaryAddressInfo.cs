namespace AutomaticSharp.Models
{
    public class TripSummaryAddressInfo
    {
        /// <summary>
        /// Location name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Pretty display of address
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Street number
        /// </summary>
        public string StreetNumber { get; set; }

        /// <summary>
        /// Street name
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// State
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }
    }
}