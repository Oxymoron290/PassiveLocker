using Microsoft.Extensions.Configuration;

namespace Ford.Pass.Connect
{
    public class Configuration
    {
        public string AuthEndpoint { get; private set; }
        public string TokenEndpoint { get; private set; }
        public string BaseEndpoint { get; private set; }
        public string ClientId { get; private set; }
        public string ApplicationId { get; private set; }
        public string VehicleIdentificationNumber { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        public Configuration(IConfiguration config)
        {
            AuthEndpoint = config["FordPass:authEndpoint"];
            TokenEndpoint = config["FordPass:tokenEndpoint"];
            BaseEndpoint = config["FordPass:baseEndpoint"];
            ClientId = config["FordPass:clientId"];
            ApplicationId = config["FordPass:applicationId"];
            VehicleIdentificationNumber = config["FordPass:vin"];
            Username = config["FordPass:username"];
            Password = config["FordPass:password"];
        }
    }
}
