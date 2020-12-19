using Newtonsoft.Json;

namespace Ford.Pass.Connect.Models
{
    public class Oil
    {
        [JsonProperty("oilLife")]
        public string OilLife { get; set; }
        [JsonProperty("oilLifeActual")]
        public int OilLifePercentage { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
    }
}
