using Newtonsoft.Json;

namespace Ford.Pass.Connect.Models
{
    public class TirePressureManagementSystem
    {
        [JsonProperty("tirePressureByLocation")]
        public dynamic TirePressureByLocation { get; set; }
        [JsonProperty("tirePressureSystemStatus")]
        public dynamic TirePressureSystemStatus { get; set; }
        [JsonProperty("dualRearWheel")]
        public dynamic DualRearWheel { get; set; }
        [JsonProperty("leftFrontTireStatus")]
        public dynamic LeftFrontTireStatus { get; set; }
        [JsonProperty("leftFrontTirePressure")]
        public dynamic LeftFrontTirePressure { get; set; }
        [JsonProperty("rightFrontTireStatus")]
        public dynamic RightFrontTireStatus { get; set; }
        [JsonProperty("rightFrontTirePressure")]
        public dynamic RightFrontTirePressure { get; set; }
        [JsonProperty("outerLeftRearTireStatus")]
        public dynamic OuterLeftRearTireStatus { get; set; }
        [JsonProperty("outerLeftRearTirePressure")]
        public dynamic OuterLeftRearTirePressure { get; set; }
        [JsonProperty("outerRightRearTireStatus")]
        public dynamic OuterRightRearTireStatus { get; set; }
        [JsonProperty("outerRightRearTirePressure")]
        public dynamic OuterRightRearTirePressure { get; set; }
        [JsonProperty("innerLeftRearTireStatus")]
        public dynamic InnerLeftRearTireStatus { get; set; }
        [JsonProperty("innerLeftRearTirePressure")]
        public dynamic InnerLeftRearTirePressure { get; set; }
        [JsonProperty("innerRightRearTireStatus")]
        public dynamic InnerRightRearTireStatus { get; set; }
        [JsonProperty("innerRightRearTirePressure")]
        public dynamic InnerRightRearTirePressure { get; set; }
        [JsonProperty("recommendedFrontTirePressure")]
        public dynamic RecommendedFrontTirePressure { get; set; }
        [JsonProperty("recommendedRearTirePressure")]
        public dynamic RecommendedRearTirePressure { get; set; }
    }
}
