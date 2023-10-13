namespace MarsRover.Test;

public class MouvementTest
{
    public static IEnumerable<object[]> CasAvancer => new[]
    {
        new object[] { PointCardinal.Nord, 1, 0 },
        new object[] { PointCardinal.Est, 0, 1 },
        new object[] { PointCardinal.Sud, -1, 0 },
        new object[] { PointCardinal.Ouest, 0, -1 },
    };

    [Theory]
    [MemberData(nameof(CasAvancer))]
    public void Avancer(PointCardinal orientationDépart, int vecteurLatitude, int vecteurLongitude)
    {
        // ETANT DONNE un rover orienté <orientationDépart>
        var rover = new Rover(orientationDépart);

        // QUAND on avance
        var étatFinal = rover.Avancer();

        // ALORS le <vecteurLatitude> est appliqué à la Latitude
        Assert.Equal(rover.Latitude + vecteurLatitude, étatFinal.Latitude);

        // ET le <vecteurLongitude> est appliqué à la Longitude
        Assert.Equal(rover.Longitude + vecteurLongitude, étatFinal.Longitude);

        // ET l'orientation reste identique
        Assert.Equal(rover.Orientation, étatFinal.Orientation);
    }
}