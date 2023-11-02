using MarsRover.Geometrie;
using MarsRover.Test.Utilities;

namespace MarsRover.Test;

public class MouvementTest
{
    private static Dictionary<PointCardinal, Point> Vecteurs => new()
    {
        { PointCardinal.Nord, new Point(Coordonnée.Zero, Coordonnée.Un) },
        { PointCardinal.Est, new Point(Coordonnée.Un, Coordonnée.Zero) },
        { PointCardinal.Sud, new Point(Coordonnée.Zero, Coordonnée.MoinsUn) },
        { PointCardinal.Ouest, new Point(Coordonnée.MoinsUn, Coordonnée.Zero) },
    };

    public static IEnumerable<object[]> CasAvancer => new CartesianData(Vecteurs, new[] { 1, 2 })
        .Select(cas =>
        {
            var kv = (KeyValuePair<PointCardinal, Point>) cas[0];
            return new[] { kv.Key, kv.Value, cas[1] };
        });

    [Theory]
    [MemberData(nameof(CasAvancer))]
    public void Avancer(PointCardinal orientationDépart, 
        Point vecteur, ushort répétitions = 1)
    {
        // ETANT DONNE un rover orienté <orientationDépart>
        var rover = new RoverBuilder().Orienté(orientationDépart).Build();

        // QUAND on avance <répétitions> fois
        var étatFinal = rover;
        for (var i = 0; i < répétitions; i++)
            étatFinal = étatFinal.Avancer();

        // ALORS le <vecteur> est appliqué aux Coordonnées <répétions> fois
        var totalMouvementsLatitude = vecteur;
        for (var i = 1; i < répétitions; i++)
            totalMouvementsLatitude += vecteur;

        Assert.Equal(rover.Coordonnées + totalMouvementsLatitude, étatFinal.Coordonnées);

        // ET l'orientation reste identique
        Assert.Equal(rover.Orientation, étatFinal.Orientation);
    }

    public static IEnumerable<object[]> CasReculer => new CartesianData(Vecteurs, new[] { 1, 2 })
        .Select(cas =>
        {
            var kv = (KeyValuePair<PointCardinal, Point>)cas[0];
            return new[] { kv.Key, - kv.Value, cas[1] };
        });

    [Theory]
    [MemberData(nameof(CasReculer))]
    public void Reculer(PointCardinal orientationDépart,
        Point vecteur, ushort répétitions = 1)
    {
        // ETANT DONNE un rover orienté <orientationDépart>
        var rover = new RoverBuilder().Orienté(orientationDépart).Build();

        // QUAND on recule <répétitions> fois
        var étatFinal = rover;
        for (var i = 0; i < répétitions; i++)
            étatFinal = étatFinal.Reculer();

        // ALORS le <vecteur> est appliqué aux Coordonnées <répétions> fois
        var totalMouvementsLatitude = vecteur;
        for (var i = 1; i < répétitions; i++)
            totalMouvementsLatitude += vecteur;

        Assert.Equal(rover.Coordonnées + totalMouvementsLatitude, étatFinal.Coordonnées);

        // ET l'orientation reste identique
        Assert.Equal(rover.Orientation, étatFinal.Orientation);
    }
}