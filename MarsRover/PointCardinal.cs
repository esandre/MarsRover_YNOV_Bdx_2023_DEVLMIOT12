namespace MarsRover;

public class PointCardinal
{
    private readonly string _nom;
    internal Point Vecteur { get; }

    public static PointCardinal Nord { get; } 
        = new (nameof(Nord), new Point(Coordonnée.Zero, Coordonnée.Un));

    public static PointCardinal Est { get; } 
        = new (nameof(Est), new Point(Coordonnée.Un, Coordonnée.Zero));

    public static PointCardinal Ouest { get; } 
        = new (nameof(Ouest), new Point(Coordonnée.MoinsUn, Coordonnée.Zero));

    public static PointCardinal Sud { get; } 
        = new (nameof(Sud), new Point(Coordonnée.Zero, Coordonnée.MoinsUn));

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

    private PointCardinal(string nom, Point vecteurDéplacement)
    {
        _nom = nom;
        Vecteur = vecteurDéplacement;
    }

    /// <inheritdoc />
    public override string ToString() => _nom;
}