using MarsRover.Console;
using MarsRover.Exploration;
using MarsRover.Planète;
using MarsRover.Topologie;

var planète = new PlanèteBuilder().DeTaille(5).Build();
var rover = new Rover(PointCardinal.Nord, planète, Point.Zero);
var console = new RoverConsole(rover);

while (console.AskCommandsAndExecuteThem())
{
}