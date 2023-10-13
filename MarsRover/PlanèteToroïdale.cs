namespace MarsRover;

public class PlanèteToroïdale : IPlanète
{
    private readonly int _taille;

    public PlanèteToroïdale(uint taille)
    {
        if (taille == 0) throw new ArgumentOutOfRangeException(nameof(taille));

        _taille = (int) taille;
    }

    public (int Latitude, int Longitude) Canoniser(int latitude, int longitude)
    {
        return (latitude % _taille, longitude % _taille);
    }
}