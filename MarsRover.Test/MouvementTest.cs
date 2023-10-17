using MarsRover.Test.Utilities;

namespace MarsRover.Test;

public class MouvementTest
{
    private static Dictionary<PointCardinal, (int Latitude, int Longitude)> Vecteurs => new()
    {
        { PointCardinal.Nord, (1, 0) },
        { PointCardinal.Est, (0, 1) },
        { PointCardinal.Sud, (-1, 0) },
        { PointCardinal.Ouest, (0, -1) },
    };

    public static IEnumerable<object[]> CasAvancer => new CartesianData(Vecteurs, new[] { 1, 2 })
        .Select(cas =>
        {
            var kv = (KeyValuePair<PointCardinal, (int Latitude, int Longitude)>) cas[0];
            return new[] { kv.Key, kv.Value.Longitude, kv.Value.Latitude, cas[1] };
        });

    [Theory]
    [MemberData(nameof(CasAvancer))]
    public void Avancer(PointCardinal orientationDépart, 
        int vecteurLatitude, int vecteurLongitude, ushort répétitions = 1)
    {
        // ETANT DONNE un rover orienté <orientationDépart>
        var rover = new RoverBuilder().Orienté(orientationDépart).Build();

        // QUAND on avance <répétitions> fois
        var étatFinal = rover;
        for (var i = 0; i < répétitions; i++)
            étatFinal = étatFinal.Avancer();

        // ALORS le <vecteurLatitude> est appliqué à la Latitude <répétitions> fois
        var totalMouvementsLatitude = vecteurLatitude * répétitions;
        Assert.Equal(rover.Latitude + totalMouvementsLatitude, étatFinal.Latitude);

        // ET le <vecteurLongitude> est appliqué à la Longitude <répétitions> fois
        var totalMouvementsLongitude = vecteurLongitude * répétitions;
        Assert.Equal(rover.Longitude + totalMouvementsLongitude, étatFinal.Longitude);

        // ET l'orientation reste identique
        Assert.Equal(rover.Orientation, étatFinal.Orientation);
    }

    public static IEnumerable<object[]> CasReculer => new CartesianData(Vecteurs, new[] { 1, 2 })
        .Select(cas =>
        {
            var kv = (KeyValuePair<PointCardinal, (int Latitude, int Longitude)>)cas[0];
            return new[] { kv.Key, - kv.Value.Longitude, - kv.Value.Latitude, cas[1] };
        });

    [Theory]
    [MemberData(nameof(CasReculer))]
    public void Reculer(PointCardinal orientationDépart,
        int vecteurLatitude, int vecteurLongitude, ushort répétitions = 1)
    {
        // ETANT DONNE un rover orienté <orientationDépart>
        var rover = new RoverBuilder().Orienté(orientationDépart).Build();

        // QUAND on recule <répétitions> fois
        var étatFinal = rover;
        for (var i = 0; i < répétitions; i++)
            étatFinal = étatFinal.Reculer();

        // ALORS le <vecteurLatitude> est soustrait à la Latitude <répétitions> fois
        var totalMouvementsLatitude = vecteurLatitude * répétitions;
        Assert.Equal(rover.Latitude + totalMouvementsLatitude, étatFinal.Latitude);

        // ET le <vecteurLongitude> est soustrait à la Longitude <répétitions> fois
        var totalMouvementsLongitude = vecteurLongitude * répétitions;
        Assert.Equal(rover.Longitude + totalMouvementsLongitude, étatFinal.Longitude);

        // ET l'orientation reste identique
        Assert.Equal(rover.Orientation, étatFinal.Orientation);
    }
}