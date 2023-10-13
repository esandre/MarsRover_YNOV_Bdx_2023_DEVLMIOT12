using MarsRover.Test.Utilities;

namespace MarsRover.Test;

public class TopologieTest
{
    // Planète 0 impossible

    [Theory]
    [InlineData(1)]
    public void PlaneteAvancer(ushort taille)
    {
        // ETANT DONNE une planète de taille <taille>
        var planète = new PlanèteToroïdale(taille);

        // ET un rover
        var rover = new RoverBuilder().SurLaPlanète(planète).Build();

        // QUAND on avance <taille> fois
        var étatFinal = rover.Avancer();

        // ALORS la position et l'orientation restent les mêmes
        Assert.Equal(rover.Latitude, étatFinal.Latitude);
        Assert.Equal(rover.Longitude, étatFinal.Longitude);
        Assert.Equal(rover.Orientation, étatFinal.Orientation);
    }
}