namespace MarsRover;

public class Rover
{
    private readonly PointCardinal _orientationDépart;

    public Rover(PointCardinal orientationDépart)
    {
        _orientationDépart = orientationDépart;
    }

    public Rover TournerADroite()
    {
        return new Rover(_orientationDépart == PointCardinal.Nord ? PointCardinal.Est : PointCardinal.Sud);
    }

    public PointCardinal Orientation => _orientationDépart;
}