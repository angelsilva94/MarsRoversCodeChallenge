namespace MarsRovers.Domain
{
    public class Grid
    {
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public Grid()
        {

        }
        public Grid(int sizeX, int sizeY)
        {
            SizeX = sizeX;
            SizeY = sizeY;
        }
        public static Grid CreateGrid(int sizeX, int sizeY)
        {   
            return new Grid(sizeX, sizeY);
        }
    }
}
