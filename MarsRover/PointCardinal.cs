namespace MarsRover;

public class PointCardinal
{
    public static PointCardinal Nord { get; } = new ();
    public static PointCardinal Est { get; } = new ();
    public static PointCardinal Ouest { get; } = new ();
    public static PointCardinal Sud { get; } = new ();

    private PointCardinal(){}
}