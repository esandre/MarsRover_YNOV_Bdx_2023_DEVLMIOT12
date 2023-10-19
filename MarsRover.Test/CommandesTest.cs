using MarsRover.Test.Utilities;

namespace MarsRover.Test;

public class CommandesTest
{
    [Theory]
    [InlineData(RoverInterpreter.CommandeAvancer, nameof(Rover.Avancer))]
    [InlineData(RoverInterpreter.CommandeReculer, nameof(Rover.Reculer))]
    [InlineData(RoverInterpreter.CommandeTournerADroite, nameof(Rover.TournerADroite))]
    [InlineData(RoverInterpreter.CommandeTournerAGauche, nameof(Rover.TournerAGauche))]
    public void Commande(char caractère, string nomMéthodeEquivalente)
    {
        // ETANT DONNE le caractère <caractère>
        // QUAND je l'applique au Rover
        var rover = RoverBuilder.Default;
        var étatFinal = rover.Exécuter(caractère);

        // ALORS le rover réagit comme si on avait appelé la méthode <nomMéthodeEquivalente>
        var roverTémoin = RoverBuilder.Default;
        var étatFinalAttendu
            = (Rover) typeof(Rover).GetMethod(nomMéthodeEquivalente)!.Invoke(roverTémoin, Array.Empty<object>())!;

        Assert.Equal(étatFinalAttendu, étatFinal, new RoverComparer());
    }

    [Fact]
    public void CaractèreInconnu()
    {
        // ETANT DONNE un caractère invalide
        const char caractère = '0';

        // QUAND je l'applique au Rover
        var rover = RoverBuilder.Default;
        void Act() => rover.Exécuter(caractère);

        // ALORS une exception est lancée
        Assert.Throws<ArgumentOutOfRangeException>(Act);
    }
}