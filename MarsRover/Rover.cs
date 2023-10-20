namespace MarsRover;

public class Rover
{
    private readonly IPlanète _planète;

    public Point Coordonnées { get; }
    public PointCardinal Orientation { get; }

    public int Latitude => Coordonnées.X;
    public int Longitude => Coordonnées.Y;

    public Rover(PointCardinal orientation, IPlanète planète, Point coordonnées)
    {
        _planète = planète;
        Coordonnées = _planète.Canoniser(coordonnées);
        Orientation = orientation;

        if(!planète.EstLibre(Coordonnées))
            throw new AtterissageImpossibleException();
    }

    public Rover TournerADroite() => new(Orientation.SuivantHoraire, _planète, Coordonnées);
    public Rover TournerAGauche() => new(Orientation.SuivantAntihoraire, _planète, Coordonnées);

    public Rover Avancer()
    {
        var nouvellesCoordonnées = Coordonnées + new Point(Orientation.VecteurLongitude, Orientation.VecteurLatitude);
        return SeDéplacerVers(nouvellesCoordonnées);
    }

    public Rover Reculer()
    {
        var nouvellesCoordonnées = Coordonnées - new Point(Orientation.VecteurLongitude, Orientation.VecteurLatitude);
        return SeDéplacerVers(nouvellesCoordonnées);
    }

    private Rover SeDéplacerVers(Point coordonnées)
    {
        if (_planète.EstLibre(coordonnées))
            return new Rover(Orientation, _planète, coordonnées);
        return this;
    }
}