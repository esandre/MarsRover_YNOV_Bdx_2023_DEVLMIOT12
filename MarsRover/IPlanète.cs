namespace MarsRover;

public interface IPlanète
{
    Point Canoniser(Point coordonnées);
    bool EstLibre(Point coordonnées);
}
