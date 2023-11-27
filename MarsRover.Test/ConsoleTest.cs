using MarsRover.Console;
using MarsRover.Exploration;
using MarsRover.Test.Utilities;

namespace MarsRover.Test;

public class ConsoleTest
{
    [Theory]
    [InlineData("aq")]
    [InlineData("qa")]
    [InlineData("q")]
    [InlineData("AQ")]
    [InlineData("QA")]
    [InlineData("Q")]
    public void QuitterTest(string sequence)
    {
        var fakeConsole = new ConsoleFake();
        var rover = new RoverBuilder().Build();
        var console = new RoverConsole(rover, fakeConsole);

        fakeConsole.EnqueueInput(sequence);

        var mustContinue = console.AskCommandsAndExecuteThem();

        Assert.False(mustContinue);
    }

    public static IEnumerable<object[]> CasInterpretation => TestPrimitives.CommandesComplexes;

    [Theory]
    [MemberData(nameof(CasInterpretation))]
    public void InterpretationTest(char a, char b)
    {
        var roverTesté = new RoverBuilder().Build();
        var roverTémoin = new RoverBuilder().Build();
        var fakeConsole = new ConsoleFake();
        var console = new RoverConsole(roverTesté, fakeConsole);

        fakeConsole.EnqueueInput(a.ToString());
        fakeConsole.EnqueueInput(b.ToString());
        while(console.AskCommandsAndExecuteThem()) {};

        roverTémoin = roverTémoin.Exécuter(a);
        roverTémoin = roverTémoin.Exécuter(b);
        Assert.Contains(roverTémoin.ToString()!, fakeConsole.Output);
    }
}