namespace MarsRover.Test;

public class RotationTest
{
    [Fact]
    public void Tourner_Droite()
    {
        // ETANT DONNE un Rover orienté Nord
        var rover = new Rover(PointCardinal.Nord);

        // QUAND il tourne à droite
        var etatAprèsOpération = rover.TournerADroite();

        // ALORS il est orienté Est
        Assert.Equal(PointCardinal.Est, etatAprèsOpération.Orientation);
    }
}