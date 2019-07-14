using System;
using MarsRover.Domain;

namespace MarsRover.Service.Route
{
    public interface IRouteService
    {
        Domain.Location ApplyCommand(Domain.Location currentLocation, char command);
    }
}