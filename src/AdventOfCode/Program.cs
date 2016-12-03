using AdventOfCode.DayOne.EasterNavigation;
using AdventOfCode.DayTwo;
using System;
using System.Collections.Generic;

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
            programs.Add(new QuitMenu());

            var menu = new MenuRunner("Main Menu", "What would you like to do?", programs);

            var control = Control.Continue;
            while (control != Control.Quit)
            {
                control = menu.Run();
            }
        }
    }
}
