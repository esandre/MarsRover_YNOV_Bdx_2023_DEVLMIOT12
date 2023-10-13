using MarsRover.Test.Utilities;

namespace MarsRover.Test;

public class RotationTest
{
    public static IEnumerable<object[]> CasTournerDroite => new[]
    {
        new []{ PointCardinal.Nord, PointCardinal.Est },
        new []{ PointCardinal.Est, PointCardinal.Sud },
        new []{ PointCardinal.Sud, PointCardinal.Ouest },
        new []{ PointCardinal.Ouest, PointCardinal.Nord },
    };

    public static IEnumerable<object[]> CasTournerGauche => CasTournerDroite
        .Select(pair => pair.Reverse().ToArray());

    [Theory]
    [MemberData(nameof(CasTournerDroite))]
    public void TournerDroite(PointCardinal origine, PointCardinal attendu)
    {
        // ETANT DONNE un Rover orienté <origine> à des coordonnées aléatoires
        var rover = new RoverBuilder()
            .Orienté(origine)
            .CoordonnéesAléatoires()
            .Build();

        // QUAND il tourne à droite
        var étatAprèsOpération = rover.TournerADroite();

        // ALORS il est orienté <attendu>
        Assert.Equal(attendu, étatAprèsOpération.Orientation);

        // ET toujours à la même position
        Assert.Equal(rover.Coordonnées, étatAprèsOpération.Coordonnées);
    }

    [Theory]
    [MemberData(nameof(CasTournerGauche))]
    public void TournerGauche(PointCardinal origine, PointCardinal attendu)
    {
        // ETANT DONNE un Rover orienté <origine> à des coordonnées aléatoires
        var rover = new RoverBuilder()
            .Orienté(origine)
            .CoordonnéesAléatoires()
            .Build();

        // QUAND il tourne à gauche
        var étatAprèsOpération = rover.TournerAGauche();

        // ALORS il est orienté <attendu>
        Assert.Equal(attendu, étatAprèsOpération.Orientation);

        // ET toujours à la même position
        Assert.Equal(rover.Coordonnées, étatAprèsOpération.Coordonnées);
    }
}