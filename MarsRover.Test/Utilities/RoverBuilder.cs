﻿using Random = System.Random;

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

        var x = Coordonnée.Zero;
        for (var valeur = 0; valeur < random.Next(); valeur++)
            x = x.Suivante;

        var y = Coordonnée.Zero;
        for (var valeur = 0; valeur < random.Next(); valeur++)
            y = y.Suivante;

        return SituéA(new Point(x, y));
    }

    public RoverBuilder SituéA(Point coordonnées)
    {
        _coordonnéesDépart = coordonnées;
        return this;
    }

    public RoverBuilder SurLaPlanèteDeTaille(uint taille)
    {
        var builder = new PlanèteBuilder().DeTailleMinimale();

        for (var tailleActuelle = 1; tailleActuelle < taille; tailleActuelle++)
            builder.AugmenterLaTailleDeLaPlanète();

        _planète = builder.Build();

        return this;
    }
}