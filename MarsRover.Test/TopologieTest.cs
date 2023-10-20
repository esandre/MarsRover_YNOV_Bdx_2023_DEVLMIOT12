using MarsRover.Test.Utilities;

namespace MarsRover.Test;

public class TopologieTest
{
    public static IEnumerable<object[]> CasPlaneteAvancerBoucle
        => new CartesianData(new[] { 1, 2 }, TestPrimitives.PointsCardinaux);

    [Theory]
    [MemberData(nameof(CasPlaneteAvancerBoucle))]
    public void PlaneteAvancerBoucle(ushort taille, PointCardinal orientation)
    {
        // ETANT DONNE une planète de taille <taille>
        // ET un rover
        var rover = new RoverBuilder()
            .SurLaPlanèteDeTaille(taille)
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
        // ET un rover orienté <orientation>
        var rover = new RoverBuilder()
            .SurLaPlanèteDeTaille(taille)
            .Orienté(orientation)
            .Build();

        // QUAND on avance <taille - 1> fois
        var étatFinal = rover;
        for (var i = 0; i < taille - 1; i++)
            étatFinal = étatFinal.Avancer();

        // ALORS l'orientation reste la même
        Assert.Equal(rover.Orientation, étatFinal.Orientation);

        // ET la position a varié de <taille - 1>
        var distanceManhattan = étatFinal.Coordonnées.DistanceAvec(rover.Coordonnées);
        var distanceAttendue = Coordonnée.MoinsUn;
        for (var i = 0; i < taille; i++)
            distanceAttendue = distanceAttendue.Suivante;
        Assert.Equal(distanceAttendue, distanceManhattan);
    }
}