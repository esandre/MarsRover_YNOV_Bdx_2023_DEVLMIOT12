namespace MarsRover;

public class Rover
{
    public PointCardinal Orientation { get; }
    public uint Latitude { get; }

    public Rover(PointCardinal orientationDépart, uint latitude = 0)
    {
        Orientation = orientationDépart;
        Latitude = latitude;
    }

    public Rover TournerADroite() => new(Orientation.SuivantHoraire);
    public Rover TournerAGauche() => new(Orientation.SuivantAntihoraire);

    public Rover Avancer() => new (Orientation, Latitude + 1U);
}