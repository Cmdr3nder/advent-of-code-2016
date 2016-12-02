using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.DayOne.EasterNavigation
{
    public class Instruction
    {
        public Instruction(Turn turn, int magnitude)
        {
            this.turn = turn;
            this.magnitude = magnitude;
        }

        public int magnitude { get; }
        public Turn turn { get; }

        public override string ToString()
        {
            return string.Format("{0}{1}", turn, magnitude);
        }
    }
}
