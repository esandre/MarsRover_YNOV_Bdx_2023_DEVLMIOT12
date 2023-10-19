namespace MarsRover.Test.Utilities;

internal class TestPrimitives
{
    public static readonly IEnumerable<PointCardinal> PointsCardinaux = new[]
        { PointCardinal.Nord, PointCardinal.Est, PointCardinal.Sud, PointCardinal.Ouest };

    public static readonly IEnumerable<char> CommandesSimples = new[]
    {
        RoverInterpreter.CommandeReculer,
        RoverInterpreter.CommandeAvancer,
        RoverInterpreter.CommandeTournerADroite,
        RoverInterpreter.CommandeTournerAGauche,
    };
}