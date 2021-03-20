using System.Collections.Generic;
using RoverChallenge.Models;

namespace RoverChallenge.Services
{
    public enum Direction
    {
        N = 1,
        S = 2,
        E = 3,
        W = 4
    }

    public class Location : ILocation
    {
        private readonly int _boundaryX;
        private readonly int _boundaryY;
        private readonly Rover _returnModel;
        private int x;
        private int y;

        public Location(Rover returnModel, int boundaryY, int boundaryX)
        {
            _returnModel = returnModel;
            _boundaryY = boundaryY;
            _boundaryX = boundaryX;
        }

        public Rover MoveRover(List<char> moves)
        {
            foreach (var item in moves)
            {
                switch (item)
                {
                    case 'M':
                        MoveForward();
                        break;
                    case 'L':
                        RotateLeft();
                        break;
                    case 'R':
                        RotateRight();
                        break;
                    default:
                        _returnModel.Message = $"Invalid move ! ({item})";
                        break;
                }

                if (!string.IsNullOrEmpty(_returnModel.Message))
                    break;
            }

            return _returnModel;
        }

        public void RotateLeft()
        {
            _returnModel.Direction = _returnModel.Direction switch
            {
                Direction.N => Direction.W,
                Direction.S => Direction.E,
                Direction.E => Direction.N,
                Direction.W => Direction.S,
                _ => _returnModel.Direction
            };
        }

        public void RotateRight()
        {
            _returnModel.Direction = _returnModel.Direction switch
            {
                Direction.N => Direction.E,
                Direction.S => Direction.W,
                Direction.E => Direction.S,
                Direction.W => Direction.N,
                _ => _returnModel.Direction
            };
        }

        public void MoveForward()
        {
            x = _returnModel.XCoordinate;
            y = _returnModel.YCoordinate;

            if (_returnModel.Direction == Direction.N)
                _returnModel.YCoordinate++;
            else if (_returnModel.Direction == Direction.S)
                _returnModel.YCoordinate--;
            else if (_returnModel.Direction == Direction.E)
                _returnModel.XCoordinate++;
            else if (_returnModel.Direction == Direction.W)
                _returnModel.XCoordinate--;

            _returnModel.Message = CheckBoundaries();
        }

        public string CheckBoundaries()
        {
            if (_returnModel.XCoordinate < 0 || _returnModel.XCoordinate > _boundaryX || _returnModel.YCoordinate < 0 ||
                _returnModel.YCoordinate > _boundaryY)
                return
                    $"Rover cannot move because it reached boundaries. Currently location : ({x},{y})";
            return null;
        }
    }
}