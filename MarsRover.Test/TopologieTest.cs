using MarsRover.Test.Utilities;

namespace MarsRover.Test;

public class TopologieTest
{
    [Fact]
    public void PlaneteZero()
    {
        // QUAND on instancie une planète de taille 0
        // ReSharper disable once ObjectCreationAsStatement
        static void Act() => new PlanèteBuilder().DeTaille(0).Build();

        // ALORS une exception est lancée
        Assert.Throws<ArgumentOutOfRangeException>(Act);
    }

    public static IEnumerable<object[]> CasPlaneteAvancerBoucle
        => new CartesianData(new[] { 1, 2 }, TestPrimitives.PointsCardinaux);

    [Theory]
    [MemberData(nameof(CasPlaneteAvancerBoucle))]
    public void PlaneteAvancerBoucle(ushort taille, PointCardinal orientation)
    {
        // ETANT DONNE une planète de taille <taille>
        var planète = new PlanèteBuilder().DeTaille(taille).Build();

        // ET un rover
        var rover = new RoverBuilder()
            .SurLaPlanète(planète)
            .Orienté(orientation)
            .Build();

        // QUAND on avance <taille> fois
        var étatFinal = rover;
        for (var i = 0; i < taille; i++)
            étatFinal = étatFinal.Avancer();

        // ALORS la position et l'orientation restent les mêmes
        Assert.Equal(rover.Coordonnées, étatFinal.Coordonnées);
        Assert.Equal(rover.Orientation, étatFinal.Orientation);
    }

    public static IEnumerable<object[]> CasPlaneteAvancer => CasPlaneteAvancerBoucle
        .Where(cas => (int) cas[0] > 1);

    [Theory]
    [MemberData(nameof(CasPlaneteAvancer))]
    public void PlaneteAvancer(ushort taille, PointCardinal orientation)
    {
        // ETANT DONNE une planète de taille <taille>
        var planète = new PlanèteBuilder().DeTaille(taille).Build();

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