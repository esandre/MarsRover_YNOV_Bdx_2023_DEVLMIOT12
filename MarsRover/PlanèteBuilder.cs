namespace MarsRover;

public class PlanèteBuilder
{
    private ushort _taille = 2;
    private Point? _obstacle;

    public PlanèteBuilder DeTailleMinimale()
    {
        _taille = 1;
        return this;
    }

    public PlanèteBuilder AugmenterLaTailleDeLaPlanète()
    {
        _taille ++;
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