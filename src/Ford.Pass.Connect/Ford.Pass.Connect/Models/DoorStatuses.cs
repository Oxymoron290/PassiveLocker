using Newtonsoft.Json;

namespace Ford.Pass.Connect.Models
{
    public class DoorStatuses
    {
        [JsonProperty("rightRearDoor")]
        public DoorStatus RightRearDoor { get; set; }
        [JsonProperty("leftRearDoor")]
        public DoorStatus LeftRearDoor { get; set; }
        [JsonProperty("driverDoor")]
        public DoorStatus DriverDoor { get; set; }
        [JsonProperty("passengerDoor")]
        public DoorStatus PassengerDoor { get; set; }
        [JsonProperty("hoodDoor")]
        public DoorStatus HoodDoor { get; set; }
        [JsonProperty("tailgateDoor")]
        public DoorStatus TailgateDoor { get; set; }
        [JsonProperty("innerTailgateDoor")]
        public DoorStatus InnerTailgateDoor { get; set; }
    }
}
