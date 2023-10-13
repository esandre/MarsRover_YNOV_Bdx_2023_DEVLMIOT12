namespace MarsRover;

public class Rover
{
    public Rover(PointCardinal orientationDépart)
    {
        Orientation = orientationDépart;
    }

    public Rover TournerADroite() => new(Orientation.SuivantHoraire);

    public PointCardinal Orientation { get; }
}