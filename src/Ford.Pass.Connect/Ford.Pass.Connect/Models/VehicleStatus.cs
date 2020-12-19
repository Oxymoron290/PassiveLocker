using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ford.Pass.Connect.Models
{
    public class VehicleStatus
    {
        [JsonProperty("vin")]
        public string VehicleIdentificationNumber { get; set; }

        [JsonProperty("lockStatus")]
        public LockStatus LockStatus { get; set; }

        [JsonProperty("alarm")]
        public Alarm Alarm { get; set; }
        [JsonProperty("PrmtAlarmEvent")]
        public AlarmEvent AlarmEvent { get; set; }
        [JsonProperty("odometer")]
        public Odometer Odometer { get; set; }
        [JsonProperty("fuel")]
        public Fuel Fuel { get; set; }
        [JsonProperty("gps")]
        public GlobalPositioningSystem GlobalPositioningSystem { get; set; }
        [JsonProperty("remoteStart")]
        public RemoteStart RemoteStart { get; set; }
        [JsonProperty("remoteStartStatus")]
        public RemoteStartStatus RemoteStartStatus { get; set; }
        [JsonProperty("battery")]
        public Battery Battery { get; set; }
        [JsonProperty("oil")]
        public Oil Oil { get; set; }
        [JsonProperty("tirePressure")]
        public TirePressure TirePressure { get; set; }
        [JsonProperty("authorization")]
        public string Authorization { get; set; }
        [JsonProperty("TPMS")]
        public TirePressureManagementSystem TirePressureManagementSystem { get; set; }
        [JsonProperty("firmwareUpgInProgress")]
        public FirmwareUpgradeInProgress FirmwareUpgradeInProgress { get; set;}
        [JsonProperty("deepSleepInProgress")]
        public DeepSleepInProgress DeepSleepInProgress { get; set; }
        [JsonProperty("ccsSettings")]
        public CombinedChargingSystemSettings CombinedChargingSystemSettings { get; set; }
        [JsonProperty("lastRefresh")]
        public string LastRefresh { get; set; }
        [JsonProperty("lastModifiedDate")]
        public string LastModifiedDate { get; set; }
        [JsonProperty("serverTime")]
        public string ServerTime { get; set; }
        [JsonProperty("batteryFillLevel")]
        public object BatteryFillLevel { get; set; }
        [JsonProperty("elVehDTE")]
        public object elVehDTE { get; set; }
        [JsonProperty("hybridModeStatus")]
        public object hybridModeStatus { get; set; }
        [JsonProperty("chargingStatus")]
        public object chargingStatus { get; set; }
        [JsonProperty("plugStatus")]
        public object plugStatus { get; set; }
        [JsonProperty("chargeStartTime")]
        public object chargeStartTime { get; set; }
        [JsonProperty("chargeEndTime")]
        public object chargeEndTime { get; set; }
        [JsonProperty("preCondStatusDsply")]
        public object preCondStatusDsply { get; set; }
        [JsonProperty("chargerPowertype")]
        public object chargerPowertype { get; set; }
        [JsonProperty("batteryPerfStatus")]
        public object batteryPerfStatus { get; set; }
        [JsonProperty("outandAbout")]
        public OutAndAbout OutAndAbout { get; set; }
        [JsonProperty("batteryChargeStatus")]
        public object batteryChargeStatus { get; set; }
        [JsonProperty("dcFastChargeData")]
        public object dcFastChargeData { get; set; }
        [JsonProperty("windowPosition")]
        public WindowPositions WindowPosition { get; set; }
        [JsonProperty("doorStatus")]
        public DoorStatuses DoorStatus { get; set; }
        [JsonProperty("ignitionStatus")]
        public IgnitionStatus IgnitionStatus { get; set; }
        [JsonProperty("batteryTracLowChargeThreshold")]
        public object batteryTracLowChargeThreshold { get; set; }
        [JsonProperty("battTracLoSocDDsply")]
        public object battTracLoSocDDsply { get; set; }
        [JsonProperty("dieselSystemStatus")]
        public object dieselSystemStatus { get; set; }
    }
}
