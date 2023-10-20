namespace MarsRover;

internal class PlanèteToroïdale : IPlanète
{
    private readonly int _taille;

    public PlanèteToroïdale(uint taille)
    {
        if (taille == 0) throw new ArgumentOutOfRangeException(nameof(taille));

        _taille = (int) taille;
    }

    public Point Canoniser(Point coordonnées) => coordonnées % _taille;

    /// <inheritdoc />
    public bool EstLibre(Point coordonnées) => true;
}