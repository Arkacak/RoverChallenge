using RoverChallenge.Services;

namespace RoverChallenge.Models
{
    public class Rover
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public Direction Direction { get; set; }
        public string Message { get; set; }
    }
}