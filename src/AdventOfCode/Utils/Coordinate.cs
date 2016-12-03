namespace AdventOfCode.Utils
{
    public class Coordinate
    {
        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int x { get; }
        public int y { get; }

        public override string ToString()
        {
            return string.Format("({0}, {1})", x, y);
        }
    }
}
