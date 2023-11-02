using MarsRover.Exploration;
using MarsRover.Planète;
using MarsRover.Topologie;

namespace MarsRover.Test.Utilities;

internal class RoverBuilder
{
    public static Rover Default => new RoverBuilder().Build();

    private PointCardinal _pointCardinal = PointCardinal.Nord;
    private IPlanète _planète = new PlanèteInfinie();
    private Point _coordonnéesDépart = Point.Zero;

    public RoverBuilder Orienté(PointCardinal pointCardinal)
    {
        _pointCardinal = pointCardinal;
        return this;
    }

    public RoverBuilder SurLaPlanète(Func<PlanèteBuilder, PlanèteBuilder> configuration)
    {
        var builder = new PlanèteBuilder();
        configuration.Invoke(builder);
        _planète = builder.Build();
        return this;
    }

    public Rover Build() => new (_pointCardinal, _planète, _coordonnéesDépart);

    public RoverBuilder CoordonnéesAléatoires()
    {
        var random = Random.Shared;
        return SituéA(new Point(random.Next(), random.Next()));
    }

    public RoverBuilder SituéA(Point coordonnées)
    {
        _coordonnéesDépart = coordonnées;
        return this;
    }
}