namespace MarsRover;

public class PlanèteBuilder
{
    private ushort _taille = 2; // TODO : type primitif
    private Point? _obstacle;

    public PlanèteBuilder DeTaille(ushort taille) // TODO : type primitif
    {
        if (taille == 0) throw new ArgumentOutOfRangeException();
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
        var planèteDeBase = PlanèteToroïdale.DeTailleUne;
        for (var taille = 1; taille < _taille; taille++)
            planèteDeBase = planèteDeBase.DeTailleSupérieure;

        IPlanète planète = planèteDeBase;
        if (_obstacle is not null) 
            planète = new PlanèteAvecObstacle(planète, _obstacle);

        return planète;
    }
}