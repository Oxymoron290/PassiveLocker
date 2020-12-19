using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Ford.Pass.Connect
{
    public class Client : IDisposable
    {
        private readonly Configuration config;
        private readonly Uri baseEndpoint;
        private readonly HttpClient client;
        private readonly ILogger<Client> logger;

        public Client(IConfiguration configuration, ILogger<Client> logger)
        {
            this.logger = logger;
            config = new Configuration(configuration);
            baseEndpoint = new Uri(config.BaseEndpoint);
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("Accept-Language", "en-us");
            //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "fordpass-na/353 CFNetwork/1121.2.2 Darwin/19.3.0");
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
        }

        public void Dispose()
        {
            client.Dispose();
        }

        public async void Auth()
        {
            var endpoint = new Uri(baseEndpoint, "v1.0/endpoint/default/token");
            client.DefaultRequestHeaders.Add("Content-Type", "application/x-www-form-urlencoded");
            var data = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("client_id", config.ClientId),
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", config.Username),
                new KeyValuePair<string, string>("password", config.Password)
            };

            using (var response = await client.PostAsync(endpoint, new FormUrlEncodedContent(data)))
            {
                var result = await response.Content.ReadAsStringAsync();
                logger.LogDebug(result);
            }
        }
    }
}
