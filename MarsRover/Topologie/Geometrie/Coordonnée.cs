using System.Text;

namespace MarsRover.Geometrie;

public record Coordonnée
{
    private Coordonnée(int Valeur)
    {
        this.Valeur = Valeur;
    }

    public static Coordonnée Zero => new(0);
    public static Coordonnée Un => new(1);
    public static Coordonnée MoinsUn => new(-1);

    public Coordonnée Suivante => new(Valeur + 1);

    private int Valeur { get; }

    public Coordonnée Absolue()
    {
        if (Valeur > 0) return this;
        return new Coordonnée(-Valeur);
    }

    public static Coordonnée operator +(Coordonnée a, Coordonnée b)
        => new(a.Valeur + b.Valeur);

    public static Coordonnée operator -(Coordonnée a, Coordonnée b)
        => new(a.Valeur - b.Valeur);

    public static Coordonnée operator %(Coordonnée a, Coordonnée b)
        => new(a.Valeur % b.Valeur);

    public static Coordonnée operator *(Coordonnée a, Coordonnée b)
        => new(a.Valeur * b.Valeur);

    public static Coordonnée operator -(Coordonnée coordonnée)
        => new(-coordonnée.Valeur);

    protected virtual bool PrintMembers(StringBuilder builder)
    {
        builder.Append(Valeur);
        return true;
    }
}