namespace MarsRover.Test;

public class MouvementTest
{
    [Fact]
    public void AvancerNord()
    {
        // ETANT DONNE un rover orienté nord
        var rover = new Rover(PointCardinal.Nord);

        // QUAND on avance
        var étatFinal = rover.Avancer();

        // ALORS la latitude s'incrémente
        Assert.Equal(rover.Latitude + 1, étatFinal.Latitude);

        // ET l'orientation reste identique
        Assert.Equal(étatFinal.Orientation, rover.Orientation);
    }
}