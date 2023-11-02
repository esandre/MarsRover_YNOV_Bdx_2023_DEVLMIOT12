namespace MarsRover.Communication;

public interface IRoverDataSender
{
    string SendCommand(string commandString);
}