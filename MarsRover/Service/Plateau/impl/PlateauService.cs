using System;
using Microsoft.Extensions.Logging;

namespace MarsRover.Service.Plateau.impl
{
    public class PlateauService : IPlateauService
    {
        private readonly ILogger<PlateauService> _logger;

        public PlateauService(ILogger<PlateauService> logger)
        {
            _logger = logger;
        }

        public bool IsLocationInBounds(Domain.Plateau plateau, Domain.Location location)
        {
            return location.XPosition >= plateau.MinXPosition &&
                   location.XPosition <= plateau.MaxXPosition &&
                   location.YPosition >= plateau.MinYPosition &&
                   location.YPosition <= plateau.MaxYPosition;
        }

        public Domain.Plateau Parse(string plateauBoundString)
        {
            var plateau = new Domain.Plateau();
            
            var bounds = plateauBoundString.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            plateau.MaxXPosition = Int32.Parse(bounds[0]);
            plateau.MaxYPosition = Int32.Parse(bounds[1]);

            _logger.LogInformation($"Plateau Created, Coordinates: {plateau}");
            
            return plateau;
        }
    }
}