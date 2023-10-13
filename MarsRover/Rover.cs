namespace MarsRover;

public class Rover
{
    public PointCardinal Orientation { get; }
    public int Latitude { get; }
    public int Longitude { get; }

    public Rover(PointCardinal orientationDépart, int latitude = 0, int longitude = 0)
    {
        Orientation = orientationDépart;
        Latitude = latitude;
        Longitude = longitude;
    }

    public Rover TournerADroite() => new(Orientation.SuivantHoraire);
    public Rover TournerAGauche() => new(Orientation.SuivantAntihoraire);

    public Rover Avancer() => new (Orientation, 
        Latitude + Orientation.VecteurLatitude,
        Latitude + Orientation.VecteurLongitude // BUG 
    );
}