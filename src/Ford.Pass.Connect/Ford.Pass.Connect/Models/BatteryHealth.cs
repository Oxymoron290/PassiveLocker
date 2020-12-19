using Newtonsoft.Json;

namespace Ford.Pass.Connect.Models
{
    public class BatteryHealth
    {
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
    }
}
