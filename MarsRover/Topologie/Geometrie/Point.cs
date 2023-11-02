namespace MarsRover.Geometrie;

public record Point(Coordonnée X, Coordonnée Y)
{
    public static readonly Point Zero = new(Coordonnée.Zero, Coordonnée.Zero);

    public static Point operator +(Point a, Point b)
        => new(a.X + b.X, a.Y + b.Y);

    public static Point operator -(Point a, Point b)
        => new(a.X - b.X, a.Y - b.Y);

    public static Point operator %(Point a, Point b)
        => new(a.X % b.X, a.Y % b.Y);

    public static Point operator *(Point a, Point b)
        => new(a.X * b.X, a.Y * b.Y);

    public static Point operator -(Point point)
        => new(-point.X, -point.Y);

    public Coordonnée DistanceAvec(Point autre)
    {
        var distanceX = (X - autre.X).Absolue();
        var distanceY = (Y - autre.Y).Absolue();
        return distanceX + distanceY;
    }
}