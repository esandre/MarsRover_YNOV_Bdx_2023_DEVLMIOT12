namespace MarsRover;

public class PointCardinal
{
    private readonly string _nom;

    public static PointCardinal Nord { get; } = new (nameof(Nord));
    public static PointCardinal Est { get; } = new (nameof(Est));
    public static PointCardinal Ouest { get; } = new (nameof(Ouest));
    public static PointCardinal Sud { get; } = new (nameof(Sud));

    private PointCardinal(string nom)
    {
        _nom = nom;
    }

    /// <inheritdoc />
    public override string ToString() => _nom;
}