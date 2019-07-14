namespace MarsRover.Service.Location
{
    public interface ILocationService
    {
        Domain.Location Move(Domain.Location currentLocation);

        Domain.Location Parse(string locationWithDirectionString);
    }
}