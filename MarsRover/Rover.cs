namespace MarsRover;

public class Rover
{
    private readonly IPlanète _planète;

    public Point Coordonnées { get; }
    public PointCardinal Orientation { get; }

    public int Latitude => Coordonnées.X.Valeur; // TODO : type primitif
    public int Longitude => Coordonnées.Y.Valeur; // TODO : type primitif

    public Rover(PointCardinal orientation, IPlanète planète, Point coordonnées)
    {
        _planète = planète;
        Coordonnées = _planète.Canoniser(coordonnées);
        Orientation = orientation;

        planète.SiCoordonnéesOccupées(Coordonnées, () => throw new AtterissageImpossibleException());
    }

    public Rover TournerADroite() => new(Orientation.SuivantHoraire, _planète, Coordonnées);
    public Rover TournerAGauche() => new(Orientation.SuivantAntihoraire, _planète, Coordonnées);

    public Rover Avancer()
    {
        var nouvellesCoordonnées = Coordonnées + Orientation.Vecteur;

        return SeDéplacerVers(nouvellesCoordonnées);
    }

    public Rover Reculer()
    {
        var nouvellesCoordonnées = Coordonnées - Orientation.Vecteur;

        return SeDéplacerVers(nouvellesCoordonnées);
    }

    private Rover SeDéplacerVers(Point coordonnées)
    {
        var rover = this;
        _planète.SiCoordonnéesLibres(coordonnées, () => rover = new Rover(Orientation, _planète, coordonnées));
        return rover;
    }
}