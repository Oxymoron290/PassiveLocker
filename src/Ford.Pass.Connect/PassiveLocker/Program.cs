using Ford.Pass.Connect;
using Ford.Pass.Connect.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace PassiveLocker
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices(args);
            var client = serviceProvider.GetService<Client>();
            Console.WriteLine("Connecting to FordPass...");
            client.Auth().Wait();
            var command = FordCommand.Lock;
            var response = client.IssueCommand(command).Result;

            int i = 1;
            CommandStatus result;
            do
            {
                Console.Write("\r                          ");
                Console.Write("\rIssuing Command");
                for(var c = i; c > 1; c--)
                {
                    Console.Write(".");
                }
                result = client.CommandStatus(command, response).Result;
                i = (i > 3) ? 1 : i + 1;
                Thread.Sleep(500);
            } while (result.Status == 552);
            
            var defaultForeground = Console.ForegroundColor;
            if (result.Status == 200)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Success");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failure");
            }
            Console.ForegroundColor = defaultForeground;

            Console.WriteLine("Done");
        }

        private static IServiceProvider ConfigureServices(string[] args)
        {
            IConfigurationBuilder configBuilder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json", true)
                .AddJsonFile("appsettings.dev.json", true)
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
