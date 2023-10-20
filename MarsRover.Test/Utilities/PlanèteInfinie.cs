namespace MarsRover.Test.Utilities;

internal class PlanèteInfinie : IPlanète
{
    /// <inheritdoc />
    public Point Canoniser(Point coordonnées) => coordonnées;

    // <inheritdoc />
    public void SiCoordonnéesLibres(Point coordonnées, Action siLibre) => siLibre();

    /// <inheritdoc />
    public void SiCoordonnéesOccupées(Point coordonnées, Action siOccupées) { }
}