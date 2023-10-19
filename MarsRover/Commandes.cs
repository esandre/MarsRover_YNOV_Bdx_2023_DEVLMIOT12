namespace MarsRover;

public static class Commandes
{
    public const char Avancer = 'A';
    public const char Reculer = 'R';
    public const char Droite = 'D';
    public const char Gauche = 'G';

    public static ICommande<Rover> Interpréter(char commande)
        => commande switch
           {
               Avancer => new CommandeAvancer(),
               Reculer => new CommandeReculer(),
               Droite  => new CommandeTournerADroite(),
               Gauche  => new CommandeTournerADroite(),
               _       => new CommandeIdempotente()
           };
}

public interface ICommande<T>
{
    T ExécuterSur(T objet);
}

public class CommandeIdempotente : ICommande<Rover>
{
    /// <inheritdoc />
    public Rover ExécuterSur(Rover objet) => objet;
}

public class CommandeAvancer : ICommande<Rover>
{
    /// <inheritdoc />
    public Rover ExécuterSur(Rover objet) => objet.Avancer();
}

public class CommandeReculer : ICommande<Rover>
{
    /// <inheritdoc />
    public Rover ExécuterSur(Rover objet) => objet.Reculer();
}

public class CommandeTournerADroite : ICommande<Rover>
{
    /// <inheritdoc />
    public Rover ExécuterSur(Rover objet) => objet.TournerADroite();
}

public class CommandeTournerAGauche : ICommande<Rover>
{
    /// <inheritdoc />
    public Rover ExécuterSur(Rover objet) => objet.TournerAGauche();
}