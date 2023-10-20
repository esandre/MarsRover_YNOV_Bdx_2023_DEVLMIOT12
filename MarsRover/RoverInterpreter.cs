namespace MarsRover;

public static class RoverInterpreter
{
    public const char CommandeAvancer = 'A';
    public const char CommandeReculer = 'R';
    public const char CommandeTournerADroite = 'D';
    public const char CommandeTournerAGauche = 'G';

    public static Rover Exécuter(this Rover rover, string commande) // TODO : type primitif
        => commande.Aggregate(rover,
            (current, commandeSimple) => current.Exécuter(commandeSimple)
        );

    public static Rover Exécuter(this Rover rover, char commande) // TODO : type primitif
    {
        switch (commande)
        {
            case CommandeReculer:
                return rover.Reculer();
            case CommandeTournerADroite:
                return rover.TournerADroite();
            case CommandeTournerAGauche:
                return rover.TournerAGauche();
            case CommandeAvancer:
                return rover.Avancer();
        }

        throw new ArgumentOutOfRangeException(nameof(commande));
    }
}