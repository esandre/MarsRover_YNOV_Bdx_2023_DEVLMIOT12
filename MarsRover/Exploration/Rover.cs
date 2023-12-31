﻿using System.Text;
using MarsRover.Planète;
using MarsRover.Topologie;

namespace MarsRover.Exploration;

public record Rover
{
    private readonly IPlanète _planète;

    public Point Coordonnées { get; }
    public PointCardinal Orientation { get; }

    public int Latitude => Coordonnées.X;
    public int Longitude => Coordonnées.Y;

    public Rover(PointCardinal orientation, IPlanète planète, Point coordonnées)
    {
        _planète = planète;
        Coordonnées = _planète.Canoniser(coordonnées);
        Orientation = orientation;

        if (!planète.EstLibre(Coordonnées))
            throw new AtterissageImpossibleException();
    }

    public Rover TournerADroite() => new(Orientation.SuivantHoraire, _planète, Coordonnées);
    public Rover TournerAGauche() => new(Orientation.SuivantAntihoraire, _planète, Coordonnées);

    public Rover Avancer()
    {
        var nouvellesCoordonnées = Coordonnées + new Point(Orientation.VecteurLongitude, Orientation.VecteurLatitude);
        return SeDéplacerVers(nouvellesCoordonnées);
    }

    public Rover Reculer()
    {
        var nouvellesCoordonnées = Coordonnées - new Point(Orientation.VecteurLongitude, Orientation.VecteurLatitude);
        return SeDéplacerVers(nouvellesCoordonnées);
    }

    private Rover SeDéplacerVers(Point coordonnées)
        => _planète.EstLibre(coordonnées)
            ? new Rover(Orientation, _planète, coordonnées)
            : this;

    protected virtual bool PrintMembers(StringBuilder builder)
    {
        builder.Append(Latitude);
        builder.Append(',');
        builder.Append(Longitude);
        builder.Append(',');
        builder.Append(Orientation);
        return true;
    }
}