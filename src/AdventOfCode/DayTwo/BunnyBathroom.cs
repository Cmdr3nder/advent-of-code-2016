using System;
using System.Collections.Generic;

namespace AdventOfCode.DayTwo
{
    public class BunnyBathroom : IProgram
    {
        public Control Run()
        {
            Console.WriteLine("BunnyBathroom run...");
            return Control.Continue;
        }

        public override string ToString()
        {
            return "Day 2: Bathroom Security";
        }
    }
}
