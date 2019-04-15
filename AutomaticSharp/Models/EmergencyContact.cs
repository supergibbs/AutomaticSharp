namespace AutomaticSharp.Models
{
    public class EmergencyContact
    {
        /// <summary>
        /// EmergencyContact Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// Email address
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Is phone mobile
        /// </summary>
        public bool IsMobile { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Emergency Contact URI
        /// </summary>
        public string Url { get; set; }
    }
}