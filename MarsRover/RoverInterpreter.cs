namespace MarsRover;

public static class RoverInterpreter
{
    public const char CommandeAvancer = 'A';
    public const char CommandeReculer = 'R';
    public const char CommandeTournerADroite = 'D';
    public const char CommandeTournerAGauche = 'G';

    public static Rover Exécuter(this Rover rover, string commande)
    {
        foreach (var commandeSimple in commande)
            rover = rover.Exécuter(commandeSimple);

        return rover;
    }

    public static Rover Exécuter(this Rover rover, char commande)
        => commande switch
           {
               CommandeReculer => rover.Reculer(),
               CommandeTournerADroite => rover.TournerADroite(),
               CommandeTournerAGauche => rover.TournerAGauche(),
               CommandeAvancer => rover.Avancer(),
               _   => throw new ArgumentOutOfRangeException(nameof(commande), "Commandes valides : ARDG")
           };
}