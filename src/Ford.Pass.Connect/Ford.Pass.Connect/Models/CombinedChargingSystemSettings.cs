using Newtonsoft.Json;

namespace Ford.Pass.Connect.Models
{
    public class CombinedChargingSystemSettings
    {
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("location")]
        public int Location { get; set; }

        [JsonProperty("vehicleConnectivity")]
        public int VehicleConnectivity { get; set; }

        [JsonProperty("vehicleData")]
        public int VehicleData { get; set; }

        [JsonProperty("drivingCharacteristics")]
        public int DrivingCharacteristics { get; set; }

        [JsonProperty("contacts")]
        public int Contacts { get; set; }

    }
}
