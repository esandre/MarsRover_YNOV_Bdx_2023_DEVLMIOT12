using MarsRover.Planète;
using MarsRover.Topologie;

namespace MarsRover.Test.Utilities;

internal class PlanèteInfinie : IPlanète
{
    /// <inheritdoc />
    public Point Canoniser(Point coordonnées) => coordonnées;

    /// <inheritdoc />
    public bool EstLibre(Point coordonnées) => true;
}