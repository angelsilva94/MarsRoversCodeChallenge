using MarsRovers.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Domain.Utils
{
    public static class CardinalDirectionUtilities
    {
        public static CardinalDirection ToCardinalDirection(this char cardinalDirection)
        {
            switch (cardinalDirection)
            {
                case 'N':
                    return CardinalDirection.North;
                case 'S':
                    return CardinalDirection.South;
                case 'E':
                    return CardinalDirection.East;
                case 'W':
                    return CardinalDirection.West;
                default:
                    return CardinalDirection.None;
            }
        }
        public static char FromCardinalDirection(this CardinalDirection cardinalDirection)
        {
            switch (cardinalDirection)
            {
                case CardinalDirection.North:
                    return 'N';
                case CardinalDirection.South:
                    return 'S';
                case CardinalDirection.East:
                    return 'E';
                case CardinalDirection.West:
                    return 'W';
                default:
                    return ' ';
            }
        }
    }
}