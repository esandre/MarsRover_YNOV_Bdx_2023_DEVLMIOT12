namespace MarsRover;

public class PointCardinal : IEquatable<PointCardinal>
{
    private readonly string _nom;

    public static PointCardinal Nord { get; } = new (nameof(Nord));
    public static PointCardinal Est { get; } = new (nameof(Est));
    public static PointCardinal Ouest { get; } = new (nameof(Ouest));
    public static PointCardinal Sud { get; } = new (nameof(Sud));

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

    internal int VecteurLatitude
    {
        get
        {
            if (this == Nord)
                return 1;

            if (this == Sud)
                return -1;

            return 0;
        }
    }

    internal int VecteurLongitude
    {
        get
        {
            if (this == Est)
                return 1;

            if (this == Ouest)
                return -1;

            return 0;
        }
    }

    private PointCardinal(string nom)
    {
        _nom = nom;
    }

    /// <inheritdoc />
    public override string ToString() => _nom;

    /// <inheritdoc />
    public bool Equals(PointCardinal? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return _nom == other._nom;
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PointCardinal)obj);
    }

    /// <inheritdoc />
    public override int GetHashCode() => _nom.GetHashCode();
    public static bool operator ==(PointCardinal? left, PointCardinal? right) => Equals(left, right);
    public static bool operator !=(PointCardinal? left, PointCardinal? right) => !Equals(left, right);
}