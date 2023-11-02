using MarsRover.Geometrie;
using MarsRover.Planete;

namespace MarsRover.Exploration;

public class Rover
{
    private readonly IPlanète _planète;
    private readonly Position _position;

    public PointCardinal Orientation => _position.Orientation;
    public Point Coordonnées => _position.Coordonnées;

    public Rover(Position position, IPlanète planète)
    {
        _planète = planète;
        _position = position with { Coordonnées = _planète.Canoniser(position.Coordonnées) };

        planète.SiCoordonnéesOccupées(_position.Coordonnées, () => throw new AtterissageImpossibleException());
    }

    public Rover TournerADroite() => new(_position.RotationHoraire(), _planète);
    public Rover TournerAGauche() => new(_position.RotationAntihoraire(), _planète);

    public Rover Avancer() => SeDéplacerVers(_position.MouvementPrograde());
    public Rover Reculer() => SeDéplacerVers(_position.MouvementRétrograde());

    private Rover SeDéplacerVers(Position position)
    {
        var rover = this;
        _planète.SiCoordonnéesLibres(position.Coordonnées,
            () => rover = new Rover(position, _planète)
        );
        return rover;
    }
}