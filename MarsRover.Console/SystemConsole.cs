using MarsRover.Console.Ports;

namespace MarsRover.Console;

internal class SystemConsole : IConsole
{
    /// <inheritdoc />
    public void WriteLine(string message) => System.Console.WriteLine(message);

    /// <inheritdoc />
    public string ReadLine() => System.Console.ReadLine() ?? string.Empty;
}