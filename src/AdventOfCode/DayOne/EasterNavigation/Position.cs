using AdventOfCode.Utils;

namespace AdventOfCode.DayOne.EasterNavigation
{
    public class Position
    {
        public Position(int x, int y, Cardinal facing)
        {
            this.x = x;
            this.y = y;
            this.facing = facing;
        }

        public int x { get; }
        public int y { get; }
        public Cardinal facing { get; }

        public override string ToString()
        {
            return string.Format("({0}, {1}) => {2}", x, y, facing);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Position p = obj as Position;
            if ((object)p == null)
            {
                return false;
            }

            return x == p.x && y == p.y && facing == p.facing;
        }

        public override int GetHashCode()
        {
            return x ^ y ^ (int)facing;
        }

        public static bool operator ==(Position a, Position b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            if ((object)a == null || (object)b == null)
            {
                return false;
            }

            return a.x == b.x && a.y == b.y && a.facing == b.facing;
        }

        public static bool operator !=(Position a, Position b)
        {
            return !(a == b);
        }
    }
}
