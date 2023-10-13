namespace MarsRover;

public record Point(int X, int Y)
{
    public static readonly Point Zero = new (0, 0);

    public static Point operator+(Point a, Point b) 
        => new(a.X + b.X, a.Y + b.Y);

    public static Point operator-(Point a, Point b) 
        => new(a.X - b.X, a.Y - b.Y);

    public static Point operator %(Point point, int valeur)
        => new(point.X % valeur, point.Y % valeur);
}