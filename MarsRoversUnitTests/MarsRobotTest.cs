using MarsRovers.Domain;
using MarsRovers.Domain.Robot;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace MarsRoversUnitTests
{
    public class MarsRobotTest
    {
        private readonly ITestOutputHelper output;
        public MarsRobotTest(ITestOutputHelper output)
        {
            this.output = output;
        }
        public static string ExpectedResult()
        {
            string result = @"1 3 N
5 1 E
";
            return result;
        }
        public static string InitialCoordinates()
        {
            return "1 2 N";
        }
        [Fact(DisplayName = "Robots are in the correct coordinates")]
        public void RobotShouldBeInRightCoordinates()
        {
            int sizeX = 5;
            int sizeY = 5;
            Grid grid = Grid.CreateGrid(sizeX, sizeY);


            Robot[] robots = new Robot[2] { new Robot(), new Robot()};
            
            robots[0].SetPositionAndDirection(grid, MarsRovers.Domain.Enums.CardinalDirection.North, new MarsRovers.Domain.Enums.Position(1, 2));
            robots[1].SetPositionAndDirection(grid, MarsRovers.Domain.Enums.CardinalDirection.East, new MarsRovers.Domain.Enums.Position(3, 3));
            
            string directionsRobotOne = "LMLMLMLMM";
            string directionsRobotTwo = "MMRMMRMRRM";
            
            Instructions instructions = new Instructions(directionsRobotOne);
            robots[0].ProcessData(instructions.GetDirections());
            
            instructions = new Instructions(directionsRobotTwo);
            robots[1].ProcessData(instructions.GetDirections());

            string result = "";
            foreach (var robot in robots)
            {
                result += robot.GetCurrentPosition() + Environment.NewLine;
            }
            output.WriteLine(result);
            Assert.Equal(ExpectedResult(), result);

        }
        [Fact(DisplayName = "Robot should fail if it moves beyond grid size")]
        public void RobotShouldThrowExcepcionWhenOutOfBoundsInGrid()
        {
            int sizeX = 5;
            int sizeY = 5;
            Grid grid = Grid.CreateGrid(sizeX, sizeY);

            Robot robot = new Robot();

            robot.SetPositionAndDirection(grid, MarsRovers.Domain.Enums.CardinalDirection.North, new MarsRovers.Domain.Enums.Position(1, 2));

            string directionsRobotOne = "LMLMLMLMMMMMMMMMM";
            Instructions instructions = new Instructions(directionsRobotOne);
            
            Assert.Throws<IndexOutOfRangeException>(()=> robot.ProcessData(instructions.GetDirections()));
        }
    }
}
