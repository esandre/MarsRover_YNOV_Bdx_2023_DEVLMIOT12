using MarsRover.Exploration;

namespace MarsRover.Test.Utilities;

internal static class ReflectionExtensions
{
    public static Rover InvoquerAction(this Rover rover, string nomMéthode)
    {
        return (Rover)typeof(Rover)
            .GetMethod(nomMéthode)!.Invoke(rover, Array.Empty<object>())!;
    }
}