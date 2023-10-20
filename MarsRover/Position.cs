namespace MarsRover;

public record Position(Point Coordonnées, PointCardinal Orientation)
{
    public Position RotationHoraire() 
        => this with { Orientation = Orientation.SuivantHoraire };

    public Position RotationAntihoraire() 
        => this with { Orientation = Orientation.SuivantAntihoraire };

    public Position MouvementPrograde()
        => this with { Coordonnées = Orientation.AppliquerVecteur(Coordonnées) };

    public Position MouvementRétrograde()
        => this with { Coordonnées = -Orientation.AppliquerVecteur(-Coordonnées) };
}