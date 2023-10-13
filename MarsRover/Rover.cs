namespace MarsRover;

public class Rover
{
    public PointCardinal Orientation { get; }
    public uint Latitude { get; }
    public uint Longitude { get; }

    public Rover(PointCardinal orientationDépart, uint latitude = 0, uint longitude = 0)
    {
        Orientation = orientationDépart;
        Latitude = latitude;
        Longitude = longitude;
    }

    public Rover TournerADroite() => new(Orientation.SuivantHoraire);
    public Rover TournerAGauche() => new(Orientation.SuivantAntihoraire);

    public Rover Avancer() => new (Orientation, 
        (uint) (Latitude + Orientation.VecteurLatitude),
        (uint) (Latitude + Orientation.VecteurLongitude)
    );
}