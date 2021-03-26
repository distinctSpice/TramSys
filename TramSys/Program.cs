using ConsoleApp.Repositories;
using ConsoleApp.Repositories.Interfaces;
using ConsoleApp.Services;
using ConsoleApp.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SwapiNet.Core.Services;
using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    partial class Program
    {
        static async Task Main(string[] args)
        {
            await InitializeSwapiNet();
            var serviceProvider = ConfigureServices();
            var starshipService = serviceProvider.GetService<IStarshipService>();

            Console.Write("How many passengers are there? ");
            var passengerCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Environment.NewLine);

            var starships = await starshipService.GetStarshipsByPassengerCount(passengerCount);

            Console.WriteLine($"Available starships for transport: {starships.Count}");

            foreach (var starship in starships)
            {
                starship.Pilots.ForEach(p => Console.WriteLine($"{starship.Name} - {p?.Name}"));
            }
            Console.ReadKey();
        }

        static async Task InitializeSwapiNet() => await ConfigurationService.InitializeAsync();

        static ServiceProvider ConfigureServices()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IPilotRepository, PilotRepository>()
                .AddSingleton<IStarshipRepository, StarshipRepository>()
                .AddSingleton<IStarshipService, StarshipService>();

            return serviceProvider.BuildServiceProvider();
        }
    }
}
