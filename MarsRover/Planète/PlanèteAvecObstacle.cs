using MarsRover.Topologie;

namespace MarsRover.Planète;

internal class PlanèteAvecObstacle : IPlanète
{
    private readonly IPlanète _planète;
    private readonly Point _obstacle;

    public PlanèteAvecObstacle(IPlanète planète, Point obstacle)
    {
        _planète = planète;
        _obstacle = obstacle;
    }

    /// <inheritdoc />
    public Point Canoniser(Point coordonnées)
    {
        return _planète.Canoniser(coordonnées);
    }

    /// <inheritdoc />
    public bool EstLibre(Point coordonnées) => _obstacle != coordonnées;
}