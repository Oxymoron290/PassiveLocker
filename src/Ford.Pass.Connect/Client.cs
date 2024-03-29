﻿using Ford.Pass.Connect.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
//using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Ford.Pass.Connect
{
    public class Client : IDisposable
    {
        private readonly Configuration config;
        private readonly Uri baseEndpoint;
        private readonly HttpClient client;
        private readonly ILogger<Client> logger;
        private TokenResponseModel token;
        private bool _authenticated;

        public Client(IConfiguration configuration, ILogger<Client> logger)
        {
            this.logger = logger;
            config = new Configuration(configuration);
            baseEndpoint = new Uri(config.BaseEndpoint);
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "fordpass-na/353 CFNetwork/1121.2.2 Darwin/19.3.0");
        }

        private void SetIAMHeaders()
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
        }

        private void SetFordHeaders(string accessToken = null)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Application-Id", config.ApplicationId);
            if (accessToken == null) accessToken = token?.AccessToken;
            if (accessToken == null) return;
            client.DefaultRequestHeaders.Add("auth-token", accessToken);
        }

        public void Dispose()
        {
            client.Dispose();
        }

        public async Task<TokenResponseModel> Auth()
        {
            var endpoint = new Uri(new Uri(config.AuthEndpoint), "v1.0/endpoint/default/token");
            logger.LogDebug($"Call to {endpoint}");
            SetIAMHeaders();
            var data = new Dictionary<string, string>
            {
                { "client_id", config.ClientId },
                { "grant_type", "password" },
                { "username", config.Username },
                { "password", config.Password }
            };

            TokenResponseModel result = null;
            try
            {
                var body = new FormUrlEncodedContent(data);
                using (var response = await client.PostAsync(endpoint, body))
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<TokenResponseModel>(responseBody);
                }
                await GetToken(result);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, ex.Message);
            }

            return result;
        }

        private async Task<TokenResponseModel> GetToken(TokenResponseModel auth)
        {
            var endpoint = new Uri(new Uri(config.TokenEndpoint), "/api/oauth2/v1/token");
            logger.LogDebug($"Call to {endpoint}");
            SetFordHeaders();
            var data = new Dictionary<string, string>
            {
                { "code", auth.AccessToken }
            };
            
            TokenResponseModel result = null;
            try
            {
                var body = new StringContent(JsonConvert.SerializeObject(data));
                //var b = new JsonContent()
                using(var response = await client.PutAsync(endpoint, body))
                {
                    this._authenticated = response.IsSuccessStatusCode;
                    var responseBody = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<TokenResponseModel>(responseBody);
                }
                token = result;
                SetFordHeaders(result.AccessToken);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, ex.Message);
            }

            return result;
        }

        private bool CheckAuth()
        {
            if (!_authenticated) return false;
            // todo: check if token is still valid and expiration

            return true;
        }

        public async Task<VehicleStatusResponse> GetStatus()
        {
            if(!CheckAuth()) return null;
            var endpoint = new Uri(baseEndpoint, $"/api/vehicles/v4/{config.VehicleIdentificationNumber}/status");
            logger.LogDebug($"Call to {endpoint}");
            VehicleStatusResponse result = null;
            using (var response = await client.GetAsync(endpoint))
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<VehicleStatusResponse>(responseBody);
            }

            return result;
        }

        public async Task<CommandResponse> IssueCommand(FordCommand command)
        {
            if(!CheckAuth()) return null;
            Task<HttpResponseMessage> operation;
            Uri endpoint;
            switch (command)
            {
                case FordCommand.Start:
                    endpoint = new Uri(baseEndpoint, $"api/vehicles/v2/{config.VehicleIdentificationNumber}/engine/start");
                    operation = client.PutAsync(endpoint, null);
                    break;
                case FordCommand.Stop:
                    endpoint = new Uri(baseEndpoint, $"api/vehicles/v2/{config.VehicleIdentificationNumber}/engine/start");
                    operation = client.DeleteAsync(endpoint);
                    break;
                case FordCommand.Lock:
                    endpoint = new Uri(baseEndpoint, $"api/vehicles/v2/{config.VehicleIdentificationNumber}/doors/lock");
                    operation = client.PutAsync(endpoint, null);
                    break;
                case FordCommand.Unlock:
                    endpoint = new Uri(baseEndpoint, $"api/vehicles/v2/{config.VehicleIdentificationNumber}/doors/lock");
                    operation = client.DeleteAsync(endpoint);
                    break;
                default:
                    throw new Exception("Invalid Ford Command");
            }

            logger.LogDebug($"Call to {endpoint}");

            CommandResponse result = null;
            using (var response = await operation)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<CommandResponse>(responseBody);
            }

            return result;
        }

        public async Task<CommandStatus> CommandStatus(FordCommand command, CommandResponse commandId)
        {
            if(!CheckAuth()) return null;
            Uri endpoint;
            switch (command)
            {
                case FordCommand.Start:
                case FordCommand.Stop:
                    endpoint = new Uri(baseEndpoint, $"api/vehicles/v2/{config.VehicleIdentificationNumber}/engine/start/{commandId.CommandId}");
                    break;
                case FordCommand.Lock:
                case FordCommand.Unlock:
                    endpoint = new Uri(baseEndpoint, $"api/vehicles/v2/{config.VehicleIdentificationNumber}/doors/lock/{commandId.CommandId}");
                    break;
                default:
                    throw new Exception("Invalid Ford Command");
            }

            logger.LogDebug($"Call to {endpoint}");
            CommandStatus result = null;
            using (var response = await client.GetAsync(endpoint))
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<CommandStatus>(responseBody);
            }

            return result;
        }
    }
}
