namespace MarsRovers.Domain.Enums
{
    public class Position
    {
        public int x { get; set; }
        public int y { get; set; }
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Position Move(CardinalDirection cardinalDirection)
        {
            switch (cardinalDirection)
            {
                case CardinalDirection.North:
                    return new Position(x, y + 1);
                case CardinalDirection.South:
                    return new Position(x , y - 1);
                case CardinalDirection.East:
                    return new Position(x + 1, y);
                case CardinalDirection.West:
                    return new Position(x -1, y);
                default:
                    return null;
            }
        }
    }
}