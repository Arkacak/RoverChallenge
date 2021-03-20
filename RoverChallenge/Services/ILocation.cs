using System.Collections.Generic;
using RoverChallenge.Models;

namespace RoverChallenge.Services
{
    public interface ILocation
    {
        public Rover MoveRover(List<char> moves);
        public void RotateLeft();
        public void RotateRight();
        public void MoveForward();

        public string CheckBoundaries();
    }
}