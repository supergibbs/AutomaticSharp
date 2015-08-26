namespace AutomaticSharp.Models
{
    public class Vehicle
    {
        public string Id { get; set; }
        
        public string Vin { get; set; }

        public int Year { get; set; }
        
        public string Make { get; set; }

        public string Model { get; set; }
        
        public string Submodel { get; set; }
        
        public string DisplayName { get; set; }
        
        public string Color { get; set; }

        public string Url { get; set; }
    }
}