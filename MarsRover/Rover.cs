namespace MarsRover;

public class Rover
{
    public PointCardinal Orientation { get; }

    public Rover(PointCardinal orientationDépart)
    {
        Orientation = orientationDépart;
    }

    public Rover TournerADroite() => new(Orientation.SuivantHoraire);
    public Rover TournerAGauche() => new(Orientation.SuivantAntihoraire);
}