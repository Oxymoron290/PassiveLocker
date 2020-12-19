using Newtonsoft.Json;

namespace Ford.Pass.Connect.Models
{
    public class CommandStatus
    {
        [JsonProperty("$id")]
        public string id { get; set; }
        [JsonProperty("eventData")]
        public dynamic EventData { get; set; }

        [JsonProperty("errorDetailCode")]
        public dynamic errorDetailCode { get; set; }
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
