namespace MarsRover;

public class Rover
{
    private readonly IPlanète _planète;
    public PointCardinal Orientation { get; }
    public int Latitude { get; }
    public int Longitude { get; }

    public Rover(PointCardinal orientationDépart, IPlanète planète, int latitude = 0, int longitude = 0)
    {
        _planète = planète;
        Orientation = orientationDépart;

        var coordonnéesCanoniques = _planète.Canoniser(latitude, longitude);

        Latitude = coordonnéesCanoniques.Latitude;
        Longitude = coordonnéesCanoniques.Longitude;
    }

    public Rover TournerADroite() => new(Orientation.SuivantHoraire, _planète);
    public Rover TournerAGauche() => new(Orientation.SuivantAntihoraire, _planète);

    public Rover Avancer() => new (Orientation, _planète, 
        Latitude + Orientation.VecteurLatitude,
        Longitude + Orientation.VecteurLongitude
    );

    public Rover Reculer() => new(Orientation, _planète,
        Latitude - Orientation.VecteurLatitude,
        Longitude - Orientation.VecteurLongitude
    );
}