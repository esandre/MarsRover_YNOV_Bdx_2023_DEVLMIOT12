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
        Assert.Equal(rover.Orientation, étatFinal.Orientation);

        // ET la longitude reste identique
        Assert.Equal(rover.Longitude, étatFinal.Longitude);
    }

    [Fact]
    public void AvancerSud()
    {
        // ETANT DONNE un rover orienté sud
        var rover = new Rover(PointCardinal.Sud);

        // QUAND on avance
        var étatFinal = rover.Avancer();

        // ALORS la latitude se décrémente
        Assert.Equal(rover.Latitude - 1, étatFinal.Latitude);

        // ET l'orientation reste identique
        Assert.Equal(rover.Orientation, étatFinal.Orientation);

        // ET la longitude reste identique
        Assert.Equal(rover.Longitude, étatFinal.Longitude);
    }

    [Fact]
    public void AvancerEst()
    {
        // ETANT DONNE un rover orienté est
        var rover = new Rover(PointCardinal.Est);

        // QUAND on avance
        var étatFinal = rover.Avancer();

        // ALORS la longitude s'incrémente
        Assert.Equal(rover.Longitude + 1, étatFinal.Longitude);

        // ET l'orientation reste identique
        Assert.Equal(rover.Orientation, étatFinal.Orientation);

        // ET la latitude reste identique
        Assert.Equal(rover.Latitude, étatFinal.Latitude);
    }

    [Fact]
    public void AvancerOuest()
    {
        // ETANT DONNE un rover orienté ouest
        var rover = new Rover(PointCardinal.Ouest);

        // QUAND on avance
        var étatFinal = rover.Avancer();

        // ALORS la longitude se décrémente
        Assert.Equal(rover.Longitude - 1, étatFinal.Longitude);

        // ET l'orientation reste identique
        Assert.Equal(rover.Orientation, étatFinal.Orientation);

        // ET la latitude reste identique
        Assert.Equal(rover.Latitude, étatFinal.Latitude);
    }
}