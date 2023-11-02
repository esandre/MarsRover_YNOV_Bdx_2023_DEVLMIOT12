using MarsRover.Geometrie;

namespace MarsRover.Planete;

internal class PlanèteToroïdale : IPlanète
{
    private readonly Point _pointMax;

    private PlanèteToroïdale(Point pointMax)
    {
        _pointMax = pointMax;
    }

    private PlanèteToroïdale()
    {
        _pointMax = new Point(Coordonnée.Un, Coordonnée.Un);
    }

    public static PlanèteToroïdale DeTailleUne => new();

    public PlanèteToroïdale DeTailleSupérieure => new(_pointMax + DeTailleUne._pointMax);

    public Point Canoniser(Point coordonnées) => coordonnées % _pointMax;

    /// <inheritdoc />
    public void SiCoordonnéesLibres(Point coordonnées, Action siLibre) => siLibre();

    /// <inheritdoc />
    public void SiCoordonnéesOccupées(Point coordonnées, Action siOccupées) { }
}