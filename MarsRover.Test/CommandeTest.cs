using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FsCheck.Xunit;
using MarsRover.Test.Utilities;

namespace MarsRover.Test;

public class CommandeTest
{
    [Theory]
    [InlineData(Commandes.Avancer, nameof(Rover.Avancer))]
    [InlineData(Commandes.Droite, nameof(Rover.TournerADroite))]
    [InlineData(Commandes.Gauche, nameof(Rover.TournerAGauche))]
    [InlineData(Commandes.Reculer, nameof(Rover.Reculer))]
    public void CommandeEtActionDonnentLeMêmeRésultat(char commande, string nameOfMethodToCall)
    {
        // ETANT DONNE une commande d'un caractère <commande>
        var command = Commandes.Interpréter(commande);

        // QUAND on applique cette commande sur le rover
        var rover = RoverBuilder.Default;
        var résultatAvecCommande = command.ExécuterSur(rover);

        // ALORS le résultat est le même que si on avait appelé la méthode <nameOfMethodToCall>
        var roverTémoin = RoverBuilder.Default;
        var résultatAttendu = typeof(Rover).GetMethod(nameOfMethodToCall)!.Invoke(roverTémoin, Array.Empty<object>());

        Assert.Equal(résultatAttendu, résultatAvecCommande);
    }
}