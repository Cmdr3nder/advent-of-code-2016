using System;

namespace AdventOfCode.DayThree
{
    public class Triangle
    {
        public Triangle(uint a, uint b, uint c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public uint a { get; }
        public uint b { get; }
        public uint c { get; }

        public bool valid {
            get
            {
                var sides = new uint[3] { a, b, c };
                Array.Sort(sides);
                return (sides[0] + sides[1]) > sides[2];
            }
        }

        public override string ToString()
        {
            return string.Format("<{0}, {1}, {2}>", a, b, c);
        }
    }
}
