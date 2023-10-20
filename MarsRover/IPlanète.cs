namespace MarsRover;

public interface IPlanète
{
    Point Canoniser(Point coordonnées);
    void SiCoordonnéesLibres(Point coordonnées, Action siLibre);
    void SiCoordonnéesOccupées(Point coordonnées, Action siOccupées);
}
