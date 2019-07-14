using System;
using MarsRover.Service.Location;
using MarsRover.Service.Location.impl;
using MarsRover.Service.Plateau;
using MarsRover.Service.Plateau.impl;
using MarsRover.Service.Route;
using MarsRover.Service.Route.impl;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = SetupDependencyContainer();
            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();
            var routeService = serviceProvider.GetService<IRouteService>();
            var plateauService = serviceProvider.GetService<IPlateauService>();
            var locationService = serviceProvider.GetService<ILocationService>();

            Console.WriteLine("Mars Rover Challenge");
            Console.WriteLine("Format: ");
            Console.WriteLine("Plateau Bounds: 5 5");
            Console.WriteLine("Rover Position and Direction: 1 3 W");
            Console.WriteLine("Move Commands: LMLMLMLMM");
            Console.WriteLine($"{Environment.NewLine}");

            Console.WriteLine("Please Enter Plateau Bounds");
            var plateauString = Console.ReadLine();
            var plateau = plateauService.Parse(plateauString);

            var exitString = "";
            do
            {
                Console.WriteLine("Please Enter Rover Location");
                var roverLocationString = Console.ReadLine();
                var roverLocation = locationService.Parse(roverLocationString);

                Console.WriteLine("Please Enter Move Command Set");
                var commandString = Console.ReadLine();
                foreach (var command in commandString)
                {
                    roverLocation = routeService.ApplyCommand(roverLocation, command);
                    
                    var isLocationInBounds = plateauService.IsLocationInBounds(plateau, roverLocation);
                    if (!isLocationInBounds)
                    {
                        logger.LogWarning($"Rover can not move with this move set, current location is out of plateau bounds: currentLocation: {roverLocation}, plateauLocation: {plateau}");
                        break;
                    }
                }
                
                Console.WriteLine($"{roverLocation}");
                Console.WriteLine("Enter -1 to Exit");
                exitString = Console.ReadLine();
            } while (!"-1".Equals(exitString));
        }

        static ServiceProvider SetupDependencyContainer()
        {
            //setup our DI
            return new ServiceCollection()
                .AddLogging(loggerFactory =>
                {
                    loggerFactory.AddConsole()
                        .AddFilter(logLevel => logLevel >= LogLevel.Debug);
                })
                .AddSingleton<IRouteService, RouteService>()
                .AddSingleton<IPlateauService, PlateauService>()
                .AddSingleton<ILocationService, LocationService>()
                .BuildServiceProvider();
        }
    }
}