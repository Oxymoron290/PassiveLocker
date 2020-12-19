using Newtonsoft.Json;

namespace Ford.Pass.Connect.Models
{
    public class RemoteStart
    {
        [JsonProperty("remoteStartDuration")]
        public int RemoteStartDuration { get; set; }
        [JsonProperty("remoteStartTime")]
        public int RemoteStartTime { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
    }
}
