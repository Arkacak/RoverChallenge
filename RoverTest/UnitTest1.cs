using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using RoverChallenge.Models;
using RoverChallenge.Services;
using Xunit;

namespace RoverTest
{
    public class UnitTest1
    {
        [Fact]
        public void MoveOrder_First_Case()
        {

            var rover = new Rover
            {
                Direction = Direction.N,
                Message = "",
                XCoordinate = 1,
                YCoordinate = 2
            };

            var service = new Location(rover, 5, 5);
            List<char> moves = new List<char> { 'L','M' ,'L','M','L','M','L','M','M'};
            service.MoveRover(moves);

            var returnedMessage =
                $"XPos: {rover.XCoordinate}, YPos: {rover.YCoordinate}, Direction : {rover.Direction}";

            var actualMessage = "XPos: 1, YPos: 3, Direction : N";

            Assert.Equal(returnedMessage,actualMessage);
        }
        [Fact]
        public void MoveOrder_Second_Case()
        {

            var rover = new Rover
            {
                Direction = Direction.E,
                Message = "",
                XCoordinate = 3,
                YCoordinate = 3
            };

            var service = new Location(rover, 5, 5);
            List<char> moves = new List<char> { 'M', 'M', 'R', 'M', 'M', 'R', 'M', 'R', 'R' ,'M'};
            service.MoveRover(moves);

            var returnedMessage =
                $"XPos: {rover.XCoordinate}, YPos: {rover.YCoordinate}, Direction : {rover.Direction}";

            var actualMessage = "XPos: 5, YPos: 1, Direction : E";

            Assert.Equal(returnedMessage, actualMessage);
        }
        [Fact]
        public void MoveOrder_OutBoundary_Case()
        {

            var rover = new Rover
            {
                Direction = Direction.N,
                Message = "",
                XCoordinate = 1,
                YCoordinate = 1
            };

            var service = new Location(rover, 3, 3);
            List<char> moves = new List<char> { 'M', 'M'};
            service.MoveRover(moves);

            var returnedMessage = $"Rover cannot move because it reached boundaries. Currently location : ({rover.XCoordinate},{rover.YCoordinate})";

            var actualMessage = "Rover cannot move because it reached boundaries. Currently location : (1,3)";

            Assert.Equal(returnedMessage, actualMessage);
        }
    }
}
