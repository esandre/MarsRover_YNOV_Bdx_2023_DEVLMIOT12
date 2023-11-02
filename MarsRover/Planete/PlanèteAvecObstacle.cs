using MarsRover.Geometrie;

namespace MarsRover.Planete;

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
    public Point Canoniser(Point coordonnées) => _planète.Canoniser(coordonnées);

    public void SiCoordonnéesLibres(Point coordonnées, Action siLibre)
    {
        if (_obstacle != coordonnées) siLibre();
    }

    /// <inheritdoc />
    public void SiCoordonnéesOccupées(Point coordonnées, Action siOccupées)
    {
        if (_obstacle == coordonnées) siOccupées();
    }
}