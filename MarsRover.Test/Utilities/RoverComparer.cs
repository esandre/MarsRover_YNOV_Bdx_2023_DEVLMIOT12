using MarsRover.Exploration;

namespace MarsRover.Test.Utilities;

internal class RoverComparer : IEqualityComparer<Rover>
{
    public bool Equals(Rover? x, Rover? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (ReferenceEquals(x, null)) return false;
        if (ReferenceEquals(y, null)) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Coordonnées.Equals(y.Coordonnées) && x.Orientation.Equals(y.Orientation);
    }

    public int GetHashCode(Rover obj) => HashCode.Combine(obj.Coordonnées, obj.Orientation);
}