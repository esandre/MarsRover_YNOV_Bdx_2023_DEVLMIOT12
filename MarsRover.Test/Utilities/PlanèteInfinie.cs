namespace MarsRover.Test.Utilities;

internal class PlanèteInfinie : IPlanète
{
    /// <inheritdoc />
    public Point Canoniser(Point coordonnées) => coordonnées;
}