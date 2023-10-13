namespace MarsRover;

public class Rover
{
    private readonly IPlanète _planète;

    public Point Coordonnées { get; }
    public PointCardinal Orientation { get; }

    public int Latitude => Coordonnées.X;
    public int Longitude => Coordonnées.Y;

    public Rover(PointCardinal orientation, IPlanète planète, Point coordonnées)
    {
        _planète = planète;
        Coordonnées = _planète.Canoniser(coordonnées);
        Orientation = orientation;
    }

    public Rover TournerADroite() => new(Orientation.SuivantHoraire, _planète, Coordonnées);
    public Rover TournerAGauche() => new(Orientation.SuivantAntihoraire, _planète, Coordonnées);

    public Rover Avancer() => new (Orientation, _planète, 
        Coordonnées + new Point(Orientation.VecteurLatitude, Orientation.VecteurLongitude)
    );

    public Rover Reculer() => new(Orientation, _planète,
        Coordonnées - new Point(Orientation.VecteurLatitude, Orientation.VecteurLongitude)
    );
}