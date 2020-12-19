using Newtonsoft.Json;

namespace Ford.Pass.Connect.Models
{
    public class WindowPositions
    {
        [JsonProperty("driverWindowPosition")]
        public WindowPosition DriverWindowPosition { get; set; }
        [JsonProperty("passWindowPosition")]
        public WindowPosition PassWindowPosition { get; set; }
        [JsonProperty("rearDriverWindowPos")]
        public WindowPosition RearDriverWindowPos { get; set; }
        [JsonProperty("rearPassWindowPos")]
        public WindowPosition RearPassWindowPos { get; set; }
    }
}
