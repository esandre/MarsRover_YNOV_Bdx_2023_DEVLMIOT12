using MarsRover.Console.Ports;
using MarsRover.Exploration;

namespace MarsRover.Console;

public class RoverConsole
{
    private readonly IConsole _console;
    private Rover _rover;

    public const char QuitCommand = 'Q';
    public static readonly string Prompt = $"Saisissez une commande ou une suite de commande. '{QuitCommand}' pour quitter";

    public RoverConsole(Rover rover) : this(rover, new SystemConsole())
    {}

    public RoverConsole(Rover rover, IConsole console)
    {
        _console = console;
        _rover = rover;
    }

    public bool AskCommandsAndExecuteThem()
    {
        _console.WriteLine(_rover.ToString()!);
        _console.WriteLine(Prompt);

        var commands = _console.ReadLine();
        if (commands.Contains(QuitCommand, StringComparison.InvariantCultureIgnoreCase))
            return false;

        try
        {
            _rover = _rover.Exécuter(commands);
        }
        catch (ArgumentOutOfRangeException e)
        {
            _console.WriteLine(e.Message);
        }

        return true;
    }
}