namespace MarsRover.Test.Utilities;

internal class RoverBuilder
{
    private PointCardinal _pointCardinal = PointCardinal.Nord;
    private IPlanète _planète = new PlanèteInfinie();

    public RoverBuilder Orienté(PointCardinal pointCardinal)
    {
        _pointCardinal = pointCardinal;
        return this;
    }

    public RoverBuilder SurLaPlanète(IPlanète planète)
    {
        _planète = planète;
        return this;
    }

    public Rover Build() => new (_pointCardinal, _planète);
}