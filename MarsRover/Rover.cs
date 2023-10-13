namespace MarsRover;

public class Rover
{
    private readonly IPlanète _planète;
    private readonly Point _coordonnées;

    public PointCardinal Orientation { get; }

    public int Latitude => _coordonnées.X;
    public int Longitude => _coordonnées.Y;

    public Rover(PointCardinal orientation, IPlanète planète)
    {
        _planète = planète;
        _coordonnées = Point.Zero;
        Orientation = orientation;
    }

    public Rover(PointCardinal orientation, IPlanète planète, Point coordonnées)
    {
        _planète = planète;
        _coordonnées = _planète.Canoniser(coordonnées);
        Orientation = orientation;
    }

    public Rover TournerADroite() => new(Orientation.SuivantHoraire, _planète);
    public Rover TournerAGauche() => new(Orientation.SuivantAntihoraire, _planète);

    public Rover Avancer() => new (Orientation, _planète, 
        _coordonnées + new Point(Orientation.VecteurLatitude, Orientation.VecteurLongitude)
    );

    public Rover Reculer() => new(Orientation, _planète,
        _coordonnées - new Point(Orientation.VecteurLatitude, Orientation.VecteurLongitude)
    );
}