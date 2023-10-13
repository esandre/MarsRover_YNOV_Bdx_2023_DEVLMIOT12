namespace MarsRover.Test;

public class MouvementTest
{
    public static IEnumerable<object[]> CasAvancer => new[]
    {
        new object[] { PointCardinal.Nord, 1, 0 },
        new object[] { PointCardinal.Est, 0, 1 },
        new object[] { PointCardinal.Sud, -1, 0 },
        new object[] { PointCardinal.Ouest, 0, -1 },
        new object[] { PointCardinal.Nord, 1, 0, 2 },
        new object[] { PointCardinal.Est, 0, 1, 2 },
        new object[] { PointCardinal.Sud, -1, 0, 2 },
        new object[] { PointCardinal.Ouest, 0, -1, 2 }
    };

    [Theory]
    [MemberData(nameof(CasAvancer))]
    public void Avancer(PointCardinal orientationDépart, 
        int vecteurLatitude, int vecteurLongitude, ushort répétitions = 1)
    {
        // ETANT DONNE un rover orienté <orientationDépart>
        var rover = new Rover(orientationDépart);

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

    public static IEnumerable<object[]> CasReculer => new[]
    {
        new object[] { PointCardinal.Sud, 1, 0 },
        new object[] { PointCardinal.Ouest, 0, 1 },
        new object[] { PointCardinal.Nord, -1, 0 },
        new object[] { PointCardinal.Est, 0, -1 },
        new object[] { PointCardinal.Sud, 1, 0, 2 },
        new object[] { PointCardinal.Ouest, 0, 1, 2 },
        new object[] { PointCardinal.Nord, -1, 0, 2 },
        new object[] { PointCardinal.Est, 0, -1, 2 }
    };

    [Theory]
    [MemberData(nameof(CasReculer))]
    public void Reculer(PointCardinal orientationDépart,
        int vecteurLatitude, int vecteurLongitude, ushort répétitions = 1)
    {
        // ETANT DONNE un rover orienté <orientationDépart>
        var rover = new Rover(orientationDépart);

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