using Microsoft.Extensions.Configuration;

namespace Ford.Pass.Connect
{
    public class Configuration
    {
        public string IDPEndpoint { get; private set; }
        public string BaseEndpoint { get; private set; }
        public string ClientId { get; private set; }
        public string VehicleIdentificationNumber { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        public Configuration(IConfiguration config)
        {
            IDPEndpoint = config["FordPass:idpEndpoint"];
            BaseEndpoint = config["FordPass:baseEndpoint"];
            ClientId = config["FordPass:clientId"];
            VehicleIdentificationNumber = config["FordPass:vin"];
            Username = config["FordPass:username"];
            Password = config["FordPass:password"];
        }
    }
}
