namespace MarsRover;

internal class PlanèteToroïdale : IPlanète
{
    private readonly Point _pointMax;

    private PlanèteToroïdale(Point pointMax)
    {
        _pointMax = pointMax;
    }

    private PlanèteToroïdale()
    {
        var un = Coordonnée.Zero.Suivante;
        _pointMax = new Point(un, un);
    }

    public static PlanèteToroïdale DeTailleUne => new();

    public PlanèteToroïdale DeTailleSupérieure => new(_pointMax + DeTailleUne._pointMax);

    public Point Canoniser(Point coordonnées) => coordonnées % _pointMax;

    /// <inheritdoc />
    public void SiCoordonnéesLibres(Point coordonnées, Action siLibre) => siLibre();

    /// <inheritdoc />
    public void SiCoordonnéesOccupées(Point coordonnées, Action siOccupées) { }
}