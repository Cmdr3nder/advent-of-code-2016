using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.DayOne.EasterNavigation
{
    public class Position
    {
        public Position(int x, int y, Direction facing)
        {
            this.x = x;
            this.y = y;
            this.facing = facing;
        }

        public int x { get; }
        public int y { get; }
        public Direction facing { get; }

        public override string ToString()
        {
            return string.Format("({0}, {1}) => {2}", x, y, facing);
        }
    }
}
