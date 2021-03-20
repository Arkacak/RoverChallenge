using System;
using System.Linq;
using RoverChallenge.Models;
using RoverChallenge.Services;

namespace RoverChallenge
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var flag = true;

            do
            {
                var rover = new Rover();

                Console.WriteLine("Please enter boundaries (like 5,4)");
                var text = Console.ReadLine()?.Split(',').ToList();

                if (text == null || text.Count < 2)
                {
                    Console.WriteLine("Please enter proper location format!");
                }
                else
                {
                    Console.WriteLine("Please enter rover's starting location (format : 1,1,N)");
                    var roverLocation = Console.ReadLine()?.Split(',').ToList();

                    if (roverLocation != null && roverLocation.Count() == 3)
                    {
                        rover.Direction = (Direction) Enum.Parse(typeof(Direction), roverLocation[2]);
                        rover.YCoordinate = int.Parse(roverLocation[1]);
                        rover.XCoordinate = int.Parse(roverLocation[0]);
                        var service = new Location(rover, int.Parse(text[0]), int.Parse(text[1]));

                        Console.WriteLine("Please enter moves order! ");
                        var moveList = Console.ReadLine().Trim().ToList();

                        rover = service.MoveRover(moveList);
                        Console.WriteLine(!string.IsNullOrEmpty(rover.Message)
                            ? rover.Message
                            : $"XPos: {rover.XCoordinate}, YPos: {rover.YCoordinate}, Direction : {rover.Direction}");
                    }
                    else
                    {
                        Console.WriteLine("Starting location format not correct !");
                    }
                }

                Console.WriteLine("1=> Another Rover 0 => Exit");
                if (int.Parse(Console.ReadLine()) == 0) flag = false;
            } while (flag);
        }
    }
}