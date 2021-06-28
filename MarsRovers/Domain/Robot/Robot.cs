using MarsRovers.Domain.Enums;
using MarsRovers.Domain.Utils;
using System;
using System.Collections.Generic;
namespace MarsRovers.Domain.Robot
{
    public class Robot: IRobot
    {
        private Grid grid { get; set; }
        private Direction direction { get; set; }
        private Position currentPosition { get; set; }
        private CardinalDirection cardinalDirection { get; set; }
        public void ProcessData(List<Direction> directions)
        {
            foreach (var direction in directions)
            {
                switch (direction)
                {
                    case Direction.Left:
                        Left();
                        break;
                    case Direction.Right:
                        Right();
                        break;
                    case Direction.Move:
                        Move();
                        break;
                    default:
                        break;
                }
            }
        }
        #region Movements
        //Add the posibilities for the movements when facing a certain cardinal position
        //ie: facing north and move left , then you are facin west
        public void Left()
        {
            switch (cardinalDirection)
            {
                case CardinalDirection.North:
                    this.cardinalDirection = CardinalDirection.West;
                    break;
                case CardinalDirection.South:
                    this.cardinalDirection = CardinalDirection.East;
                    break;
                case CardinalDirection.East:
                    this.cardinalDirection = CardinalDirection.North;
                    break;
                case CardinalDirection.West:
                    this.cardinalDirection = CardinalDirection.South;
                    break;
                default:
                    break;
            }
        }
        public void Right()
        {
            switch (cardinalDirection)
            {
                case CardinalDirection.North:
                    this.cardinalDirection = CardinalDirection.East;
                    break;
                case CardinalDirection.South:
                    this.cardinalDirection = CardinalDirection.West;
                    break;
                case CardinalDirection.East:
                    this.cardinalDirection = CardinalDirection.South;
                    break;
                case CardinalDirection.West:
                    this.cardinalDirection = CardinalDirection.North;
                    break;
                default:
                    break;
            }
        }
        public void Move()
        {
            //verify the current position x,y with grid size, if moving beyond the grid throw IndexOutOfRangeException
            if (currentPosition.x <= grid.SizeX && currentPosition.y <= grid.SizeY)
            {
                Position position = currentPosition.Move(this.cardinalDirection);
                currentPosition = position;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        #endregion
        public void SetPositionAndDirection(Grid grid, CardinalDirection cardinalDirection, Position position)
        {
            this.currentPosition = position;
            this.cardinalDirection = cardinalDirection;
            this.direction = direction;
            this.grid = grid;
        }
        public string GetCurrentPosition()
        {
            return this.currentPosition.x + " " + this.currentPosition.y + " " + this.cardinalDirection.FromCardinalDirection();
        }
    }
}
