namespace MarsRover;

public record Coordonnée 
{
    private Coordonnée(int Valeur)
    {
        this.Valeur = Valeur;
    }

    public static Coordonnée Zero => new (0);

    public Coordonnée Suivante => new(Valeur + 1);
    public Coordonnée Précédent => new(Valeur - 1);

    public int Valeur { get; } // TODO : Primitive

    public static Coordonnée operator+(Coordonnée a, Coordonnée b) 
        => new(a.Valeur + b.Valeur);

    public static Coordonnée operator-(Coordonnée a, Coordonnée b) 
        => new(a.Valeur - b.Valeur);
    
    public static Coordonnée operator%(Coordonnée a, Coordonnée b) 
        => new(a.Valeur % b.Valeur);
}