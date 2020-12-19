using Ford.Pass.Connect;
using Ford.Pass.Connect.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.IO;

namespace PassiveLocker
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices(args);

            var client = serviceProvider.GetService<Client>();
            client.Auth().Wait();
            var command = FordCommand.Lock;
            var response = client.IssueCommand(command).Result;

            CommandStatus result;
            do
            {
                result = client.CommandStatus(command, response).Result;
            } while (result.Status == 552);

            if (result.Status == 200)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("Failure");
            }
        }

        private static IServiceProvider ConfigureServices(string[] args)
        {
            IConfigurationBuilder configBuilder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json", true)
                .AddEnvironmentVariables()
                .AddCommandLine(args);

            IConfiguration config = configBuilder.Build();

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("log.txt")
                .CreateLogger();
            var services = new ServiceCollection();
            services.AddSingleton(config);
            services.AddLogging(builder => builder.AddSerilog(dispose: true));
            services.AddTransient<Client>();

            return services.BuildServiceProvider();
        }
    }
}
