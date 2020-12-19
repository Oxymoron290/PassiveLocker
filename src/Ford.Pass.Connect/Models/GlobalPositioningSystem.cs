using Newtonsoft.Json;

namespace Ford.Pass.Connect.Models
{
    public class GlobalPositioningSystem
    {
        [JsonProperty("latitude")]
        public string Latitude { get; set; }
        [JsonProperty("longitude")]
        public string Longitude { get; set; }
        [JsonProperty("gpsState")]
        public string GPSState { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
    }
}
