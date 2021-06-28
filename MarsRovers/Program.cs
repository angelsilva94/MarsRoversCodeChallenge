using MarsRovers.Domain;
using MarsRovers.Domain.Enums;
using MarsRovers.Domain.Robot;
using MarsRovers.Domain.Utils;
using System;

namespace MarsRovers
{
    class Program
    {
        //Ok sho here is the we call the implemtation of the objects, 
        static void Main(string[] args)
        {
            Grid grid;
            Console.WriteLine("Mars Rovers Problem");
            Console.WriteLine("Enter the size of the grid, separated by a space, ie: 5 5");

            string gridSize = Console.ReadLine().ToUpper();
            var splitted = gridSize.Split(" ");
            int sizeX = int.Parse(splitted[0]);
            int sizeY = int.Parse(splitted[1]);
            grid = Grid.CreateGrid(sizeX, sizeY);
            Console.WriteLine("Enter the position fot the 1 robot in the grid, separated by a space, ie: 1 2 N");
            
            Robot robot1 = new Robot();
            string positionGrid = Console.ReadLine().ToUpper();
            var positionGridSplit = positionGrid.Split(" ");
            int positionX = int.Parse(positionGridSplit[0]);
            int positionY = int.Parse(positionGridSplit[1]);
            char cardinalDirection = positionGridSplit[2].ToCharArray()[0];

            robot1.SetPositionAndDirection(grid, cardinalDirection.ToCardinalDirection(), new Position(positionX, positionY));

            Console.WriteLine("Enter the instructions ie: LRMMLR");
            string input = Console.ReadLine().ToUpper();

            Instructions instructions = new Instructions(input);
            var directions = instructions.GetDirections();
            robot1.ProcessData(directions);
            
            Console.WriteLine("Enter the position fot the 2 robot in the grid, separated by a space, ie: 1 2 N");
            Robot robot2 = new Robot();

            positionGrid = Console.ReadLine().ToUpper();
            positionGridSplit = positionGrid.Split(" ");
            positionX = int.Parse(positionGridSplit[0]);
            positionY = int.Parse(positionGridSplit[1]);

            cardinalDirection = positionGridSplit[2].ToCharArray()[0];

            robot2.SetPositionAndDirection(grid, cardinalDirection.ToCardinalDirection(), new Position(positionX, positionY));

            Console.WriteLine("Enter the instructions ie: LRMMLR");
            input = Console.ReadLine().ToUpper();
            instructions = new Instructions(input);
            directions = instructions.GetDirections();
            robot2.ProcessData(directions);

            Console.WriteLine(robot1.GetCurrentPosition());
            Console.WriteLine(robot2.GetCurrentPosition());
            Console.ReadKey();
        }
    }
}
