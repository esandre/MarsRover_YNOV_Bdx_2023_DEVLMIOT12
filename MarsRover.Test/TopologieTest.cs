using MarsRover.Test.Utilities;

namespace MarsRover.Test;

public class TopologieTest
{
    // Planète 0 impossible

    [Theory]
    [InlineData(1)]
    public void PlaneteAvancerBoucle(ushort taille)
    {
        // ETANT DONNE une planète de taille <taille>
        var planète = new PlanèteToroïdale(taille);

        // ET un rover
        var rover = new RoverBuilder().SurLaPlanète(planète).Build();

        // QUAND on avance <taille> fois
        var étatFinal = rover;
        for (var i = 0; i < taille; i++)
            étatFinal = étatFinal.Avancer();

        // ALORS la position et l'orientation restent les mêmes
        Assert.Equal(rover.Latitude, étatFinal.Latitude);
        Assert.Equal(rover.Longitude, étatFinal.Longitude);
        Assert.Equal(rover.Orientation, étatFinal.Orientation);
    }

    public static IEnumerable<object[]> CasPlaneteAvancer => new[]
    {
        new object[] { 2, PointCardinal.Est },
        new object[] { 2, PointCardinal.Sud },
        new object[] { 2, PointCardinal.Ouest },
        new object[] { 2, PointCardinal.Nord },
    };

    [Theory]
    [MemberData(nameof(CasPlaneteAvancer))]
    public void PlaneteAvancer(ushort taille, PointCardinal orientation)
    {
        // ETANT DONNE une planète de taille <taille>
        var planète = new PlanèteToroïdale(taille);

        // ET un rover orienté <orientation>
        var rover = new RoverBuilder()
            .SurLaPlanète(planète)
            .Orienté(orientation)
            .Build();

        // QUAND on avance <taille - 1> fois
        var étatFinal = rover;
        for (var i = 0; i < taille - 1; i++)
            étatFinal = étatFinal.Avancer();

        // ALORS l'orientation reste la même
        Assert.Equal(rover.Orientation, étatFinal.Orientation);

        // ET la position a varié de <taille - 1>
        var deltaLatitude = Math.Abs(étatFinal.Latitude - rover.Latitude);
        var deltaLongitude = Math.Abs(étatFinal.Longitude - rover.Longitude);
        var distanceManhattan = deltaLatitude + deltaLongitude;

        Assert.Equal(taille - 1, distanceManhattan);
    }
}