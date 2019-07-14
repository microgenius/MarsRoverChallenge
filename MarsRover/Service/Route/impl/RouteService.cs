using MarsRover.Domain;
using MarsRover.Service.Location;
using Microsoft.Extensions.Logging;

namespace MarsRover.Service.Route.impl
{
    public class RouteService : IRouteService
    {
        private readonly ILocationService _locationService;
        private readonly ILogger<RouteService> _logger;

        public RouteService(ILocationService locationService, ILogger<RouteService> logger)
        {
            _locationService = locationService;
            _logger = logger;
        }

        public Domain.Location ApplyCommand(Domain.Location currentLocation, char command)
        {
            switch (command)
            {
                case 'L':
                    currentLocation.Direction.TurnLeft();
                    break;
                case 'R':
                    currentLocation.Direction.TurnRight();
                    break;
                case 'M':
                    return _locationService.Move(currentLocation);
                default:
                    _logger.LogWarning($"Wrong Command: {command}, Valid Command set are: L, R, M");
                    break;
            }

            return currentLocation;
        }
    }
}