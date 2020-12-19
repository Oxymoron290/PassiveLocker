using Newtonsoft.Json;

namespace Ford.Pass.Connect.Models
{
    public class CommandResponse
    {
        [JsonProperty("$id")]
        public string id { get; set; }
        [JsonProperty("commandId")]
        public string CommandId { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
