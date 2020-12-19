using Newtonsoft.Json;

namespace Ford.Pass.Connect.Models
{
    public class Fuel
    {
        [JsonProperty("fuelLevel")]
        public decimal FuelLevel { get; set; }
        [JsonProperty("distanceToEmpty")]
        public decimal DistanceToEmpty { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
    }
}
