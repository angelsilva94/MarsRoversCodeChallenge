using MarsRovers.Domain.Enums;
using System.Collections.Generic;
namespace MarsRovers.Domain
{
    public class Instructions
    {
        private string instructions;
        public Instructions(string instructions)
        {
            this.instructions = instructions;
        }
        public List<Direction> GetDirections()
        {
            List<Direction> directions = new List<Direction>();
            var array = this.instructions.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                switch (array[i])
                {
                    case 'L':
                        directions.Add(Direction.Left);
                        break;
                    case 'R':
                        directions.Add(Direction.Right);
                        break;
                    case 'M':
                        directions.Add(Direction.Move);
                        break;
                    default:
                        break;
                }
            }
            return directions;
        }
    }
}
