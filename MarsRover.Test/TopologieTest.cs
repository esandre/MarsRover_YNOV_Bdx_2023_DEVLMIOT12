using MarsRover.Test.Utilities;

namespace MarsRover.Test;

public class TopologieTest
{
    // Planète 0 impossible

    [Fact]
    public void PlaneteMinimale()
    {
        // ETANT DONNE une planète de taille 1
        var planète = new PlanèteToroïdale(taille: 1);

        // ET un rover
        var rover = new RoverBuilder().SurLaPlanète(planète).Build();

        // QUAND on avance
        var étatFinal = rover.Avancer();

        // ALORS la position et l'orientation restent les mêmes
        Assert.Equal(rover.Latitude, étatFinal.Latitude);
        Assert.Equal(rover.Longitude, étatFinal.Longitude);
        Assert.Equal(rover.Orientation, étatFinal.Orientation);
    }
}