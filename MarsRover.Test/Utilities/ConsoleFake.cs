using System.Text;
using MarsRover.Console.Ports;

namespace MarsRover.Test.Utilities;

internal class ConsoleFake : IConsole
{
    private readonly StringBuilder _output = new();
    private readonly Queue<string> _inputs = new ();
    public IEnumerable<string> Output => _output.ToString().Split(Environment.NewLine);

    /// <inheritdoc />
    public void WriteLine(string message)
    {
        _output.AppendLine(message);
    }

    /// <inheritdoc />
    public string ReadLine()
    {
        return _inputs.Any() ? _inputs.Dequeue() : "q";
    }

    public void EnqueueInput(string input)
    {
        _inputs.Enqueue(input);
    }
}