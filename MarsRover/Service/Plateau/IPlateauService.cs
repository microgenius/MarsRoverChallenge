namespace MarsRover.Service.Plateau
{
    public interface IPlateauService
    {
        bool IsLocationInBounds(Domain.Plateau plateau, Domain.Location location);

        Domain.Plateau Parse(string plateauBoundString);
    }
}