using Newtonsoft.Json;

namespace Ford.Pass.Connect.Models
{
    public class Battery
    {
        [JsonProperty("batteryHealth")]
        public BatteryHealth Health { get; set; }
        [JsonProperty("batteryStatusActual")]
        public BatteryStatusActual Status { get; set; }
    }
}
