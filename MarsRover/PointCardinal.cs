namespace MarsRover;

public class PointCardinal
{
    private readonly string _nom;

    public static PointCardinal Nord { get; } 
        = new (nameof(Nord), new Point(Coordonnée.Zero, Coordonnée.Zero.Suivante));

    public static PointCardinal Est { get; } 
        = new (nameof(Est), new Point(Coordonnée.Zero.Suivante, Coordonnée.Zero));

    public static PointCardinal Ouest { get; } 
        = new (nameof(Ouest), new Point(Coordonnée.Zero.Précédent, Coordonnée.Zero));

    public static PointCardinal Sud { get; } 
        = new (nameof(Sud), new Point(Coordonnée.Zero, Coordonnée.Zero.Précédent));

    internal PointCardinal SuivantHoraire
    {
        get
        {

            if (this == Nord)
                return Est;

            if (this == Est)
                return Sud;

            if (this == Ouest)
                return Nord;

            return Ouest;
        }
    }

    internal PointCardinal SuivantAntihoraire => SuivantHoraire.SuivantHoraire.SuivantHoraire;

    internal Point Vecteur { get; }

    private PointCardinal(string nom, Point vecteurDéplacement)
    {
        _nom = nom;
        Vecteur = vecteurDéplacement;
    }

    /// <inheritdoc />
    public override string ToString() => _nom;
}