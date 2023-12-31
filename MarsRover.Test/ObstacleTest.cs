﻿using MarsRover.Exploration;
using MarsRover.Test.Utilities;
using MarsRover.Topologie;

namespace MarsRover.Test;

public class ObstacleTest
{
    [Fact]
    public void ImpossibleAtterirSurObstacle()
    {
        // ETANT DONNE un obstacle sur une position
        // ET un Rover tentant d'y atterir
        var coordonnéesObstacle = new Point(0, 0);

        // QUAND on instancie le rover
        void Act() => new RoverBuilder()
            .SurLaPlanète(planète => planète
                .DeTaille(1) // 0,0 est donc le seul point possible
                .AyantUnObstacle(coordonnéesObstacle))
            .Build();

        // ALORS une exception signale un atterissage impossible
        Assert.Throws<AtterissageImpossibleException>(Act);
    }

    [Fact]
    public void ImpossibleDAvancerSurObstacle()
    {
        // ETANT DONNE un obstacle sur une position
        var coordonnéesObstacle = new Point(0, 1);

        // ET un rover orienté nord, sur la case immédiatement au sud
        var coordonnéesRover = new Point(0, 0);
        var étatInitial = new RoverBuilder()
            .Orienté(PointCardinal.Nord)
            .SituéA(coordonnéesRover)
            .SurLaPlanète(planète => planète
                .AyantUnObstacle(coordonnéesObstacle))
            .Build();

        // QUAND le rover avance
        var étatFinal = étatInitial.Avancer();

        // ALORS sa position reste identique
        Assert.Equal(étatInitial, étatFinal, new RoverComparer());
    }

    [Fact]
    public void ImpossibleDeReculeSurObstacle()
    {
        // ETANT DONNE un obstacle sur une position
        var coordonnéesObstacle = new Point(0, 1);

        // ET un rover orienté sud, sur la case immédiatement au sud
        var coordonnéesRover = new Point(0, 0);
        var étatInitial = new RoverBuilder()
            .Orienté(PointCardinal.Sud)
            .SituéA(coordonnéesRover)
            .SurLaPlanète(planète => planète
                .AyantUnObstacle(coordonnéesObstacle))
            .Build();

        // QUAND le rover recule
        var étatFinal = étatInitial.Reculer();

        // ALORS sa position reste identique
        Assert.Equal(étatInitial, étatFinal, new RoverComparer());
    }
}