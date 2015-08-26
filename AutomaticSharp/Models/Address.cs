namespace AutomaticSharp.Models
{
    public class Address
    {
        public string Name { get; set; }

        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public string DisplayName { get; set; }
    }
}