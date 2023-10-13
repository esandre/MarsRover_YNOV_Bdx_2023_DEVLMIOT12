namespace MarsRover.Test.Utilities;

internal class PlanèteInfinie : IPlanète
{
    /// <inheritdoc />
    public (int Latitude, int Longitude) Canoniser(int latitude, int longitude) 
        => (latitude, longitude);
}