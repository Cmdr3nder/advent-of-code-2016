using AdventOfCode.DayOne.EasterNavigation;
using AdventOfCode.DayTwo;
using AdventOfCode.DayThree;
using AdventOfCode.Utils;
using System;
using System.Collections.Generic;
using AdventOfCode.DayFour;
using AdventOfCode.DayFive;
using AdventOfCode.DaySix;

namespace AdventOfCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Advent of Code 2016 - Ender4021");

            var programs = new List<IProgram>();
            programs.Add(new EasterNavigation());
            programs.Add(new BunnyBathroom());
            programs.Add(new SquareTriangles());
            programs.Add(new ObscureSecure());
            programs.Add(new ChessPass());
            programs.Add(new CommonChars());
            programs.Add(new QuitMenu());

            var menu = new Menu<IProgram>("What would you like to do?", programs);

            var control = Control.Continue;
            while (control != Control.Quit)
            {
                control = menu.Ask().Run();
            }
        }
    }
}
