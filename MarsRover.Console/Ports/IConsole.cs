namespace MarsRover.Console.Ports;

public interface IConsole
{
    void WriteLine(string message);
    string ReadLine();
}