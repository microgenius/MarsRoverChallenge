using System;
using System.Linq;
using MarsRover.Domain;
using Microsoft.Extensions.Logging;

namespace MarsRover.Service.Location.impl
{
    public class LocationService : ILocationService
    {
        private const int PARSED_X_POSITION_INDEX = 0;
        private const int PARSED_Y_POSITION_INDEX = 1;
        private const int PARSED_DIRECTION_INDEX = 2;
        private readonly ILogger<LocationService> _logger;

        public LocationService(ILogger<LocationService> logger)
        {
            _logger = logger;
        }

        public Domain.Location Move(Domain.Location currentLocation)
        {
            var newLocation = new Domain.Location();
            newLocation.Direction = currentLocation.Direction;
            newLocation.XPosition = currentLocation.XPosition;
            newLocation.YPosition = currentLocation.YPosition;

            switch (newLocation.Direction.CurrentDirection)
            {
                case eDirection.North:
                    newLocation.YPosition++;
                    break;
                case eDirection.West:
                    newLocation.XPosition--;
                    break;
                case eDirection.South:
                    newLocation.YPosition--;
                    break;
                case eDirection.East:
                    newLocation.XPosition++;
                    break;
            }

            _logger.LogInformation($"Location has changed, Old Location: {currentLocation}, New Location: {newLocation}");
            
            return newLocation;
        }

        public Domain.Location Parse(string locationWithDirectionString)
        {
            var locationStringParts = locationWithDirectionString.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            
            var location = new Domain.Location();
            location.XPosition = Int32.Parse(locationStringParts[PARSED_X_POSITION_INDEX]);
            location.YPosition = Int32.Parse(locationStringParts[PARSED_Y_POSITION_INDEX]);

            var directionChar = locationStringParts[PARSED_DIRECTION_INDEX]
                .ToUpper()
                .First();
            location.ParseToDirection(directionChar);

            _logger.LogInformation($"Created Location: {location}");
            
            return location;
        }
    }
}