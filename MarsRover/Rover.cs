namespace MarsRover;

public class Rover
{
    public Rover(PointCardinal orientationDépart)
    {
        Orientation = orientationDépart;
    }

    public Rover TournerADroite()
    {
        if(Orientation == PointCardinal.Nord)
            return new Rover(PointCardinal.Est);

        if (Orientation == PointCardinal.Est)
            return new Rover(PointCardinal.Sud);

        if (Orientation == PointCardinal.Ouest)
            return new Rover(PointCardinal.Nord);

        return new Rover(PointCardinal.Ouest);
    }

    public PointCardinal Orientation { get; }
}