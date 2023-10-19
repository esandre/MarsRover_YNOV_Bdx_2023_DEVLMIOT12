namespace MarsRover;

public class PlanèteBuilder
{
    private ushort _taille = 2;

    public PlanèteBuilder DeTaille(ushort taille)
    {
        _taille = taille;
        return this;
    }

    public IPlanète Build()
    {
        return new PlanèteToroïdale(_taille);
    }
}