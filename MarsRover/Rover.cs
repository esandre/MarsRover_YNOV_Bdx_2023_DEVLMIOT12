namespace MarsRover;

public class Rover
{
    public Rover(PointCardinal orientationDépart)
    {
    }

    public Rover TournerADroite()
    {
        return this;
    }

    public PointCardinal Orientation => PointCardinal.Est;
}