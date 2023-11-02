using MarsRover.Exploration;
using MarsRover.Topologie;

namespace MarsRover.Test.Utilities;

internal static class TestPrimitives
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