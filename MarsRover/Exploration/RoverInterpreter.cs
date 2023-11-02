namespace MarsRover.Exploration;

public static class RoverInterpreter
{
    public const char CommandeAvancer = 'A';
    public const char CommandeReculer = 'R';
    public const char CommandeTournerADroite = 'D';
    public const char CommandeTournerAGauche = 'G';

    private static readonly IDictionary<char, Func<Rover, Rover>> Commandes =
        new Dictionary<char, Func<Rover, Rover>>
        {
            { CommandeAvancer, rover => rover.Avancer() },
            { CommandeReculer, rover => rover.Reculer() },
            { CommandeTournerADroite, rover => rover.TournerADroite() },
            { CommandeTournerAGauche, rover => rover.TournerAGauche() },
        };

    public static Rover Exécuter(this Rover rover, string commande)
        => commande.Aggregate(rover,
            (current, commandeSimple) => current.Exécuter(commandeSimple)
        );

    public static Rover Exécuter(this Rover rover, char commande)
    {
        if (!Commandes.ContainsKey(commande))
            throw new ArgumentOutOfRangeException(nameof(commande));

        return Commandes[commande](rover);
    }
}