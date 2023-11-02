using MarsRover.Topologie;

namespace MarsRover.Planète;

public class PlanèteBuilder
{
    private ushort _taille = 2;
    private Point? _obstacle;

    public PlanèteBuilder DeTaille(ushort taille)
    {
        _taille = taille;
        return this;
    }

    public PlanèteBuilder AyantUnObstacle(Point obstacle)
    {
        _obstacle = obstacle;
        return this;
    }

    public IPlanète Build()
    {
        IPlanète planète = new PlanèteToroïdale(_taille);

        if (_obstacle is not null)
            planète = new PlanèteAvecObstacle(planète, _obstacle);

        return planète;
    }
}