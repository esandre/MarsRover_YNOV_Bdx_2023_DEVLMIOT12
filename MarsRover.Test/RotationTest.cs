namespace MarsRover.Test;

public class RotationTest
{
    public static IEnumerable<object[]> Cas_Tourner_Droite => new[]
    {
        new []{ PointCardinal.Nord, PointCardinal.Est },
        new []{ PointCardinal.Est, PointCardinal.Sud },
        new []{ PointCardinal.Sud, PointCardinal.Ouest },
    };

    [Theory]
    [MemberData(nameof(Cas_Tourner_Droite))]
    public void Tourner_Droite(PointCardinal origine, PointCardinal attendu)
    {
        // ETANT DONNE un Rover orienté <origine>
        var rover = new Rover(origine);

        // QUAND il tourne à droite
        var etatAprèsOpération = rover.TournerADroite();

        // ALORS il est orienté <attendu>
        Assert.Equal(attendu, etatAprèsOpération.Orientation);
    }
}