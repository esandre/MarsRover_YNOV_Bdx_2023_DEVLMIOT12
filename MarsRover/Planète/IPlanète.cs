using MarsRover.Topologie;

namespace MarsRover.Planète;

public interface IPlanète
{
    Point Canoniser(Point coordonnées);
    bool EstLibre(Point coordonnées);
}
