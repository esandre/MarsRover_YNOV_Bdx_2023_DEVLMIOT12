namespace MarsRover.Topologie;

public class PointCardinal
{
    private readonly string _nom;

    public static PointCardinal Nord { get; } = new (nameof(Nord), vecteurLatitude: 1);
    public static PointCardinal Est { get; } = new (nameof(Est), vecteurLongitude: 1);
    public static PointCardinal Ouest { get; } = new (nameof(Ouest), vecteurLongitude: -1);
    public static PointCardinal Sud { get; } = new (nameof(Sud), vecteurLatitude: -1);

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

    internal int VecteurLatitude { get; }
    internal int VecteurLongitude { get; }

    private PointCardinal(string nom, int vecteurLatitude = 0, int vecteurLongitude = 0)
    {
        _nom = nom;
        VecteurLatitude = vecteurLatitude;
        VecteurLongitude = vecteurLongitude;
    }

    /// <inheritdoc />
    public override string ToString() => _nom;
}