using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode.DayOne.EasterNavigation
{
    public class EasterNavigation : IProgram
    {
        public Control Run()
        {
            Console.WriteLine("Please Input Instructions:");
            Console.Write(">");

            var instructions = ConvertInstructions(Console.ReadLine().Trim());
            var position = new Position(0, 0, Direction.North);
            position = ApplyInstructions(position, instructions);

            var blocks = Math.Abs(position.x) + Math.Abs(position.y);
            Console.WriteLine("You are {0} blocks from your drop point.", blocks);

            return Control.Continue;
        }

        public List<Instruction> ConvertInstructions(string str)
        {
            var instructions = new List<Instruction>();

            var regex = new Regex("\\s*,\\s*");
            foreach (var s in regex.Split(str))
            {
                instructions.Add(ConvertInstruction(s));
            }

            return instructions;
        }

        public Instruction ConvertInstruction(string str)
        {
            var regex = new Regex("(?<test>L|R)(?<testy>[0-9]*)");
            var match = regex.Match(str);
            var turn = (match.Captures[0].Value == "L" ? Turn.L : Turn.R);
            var magnitude = int.Parse(match.Captures[1].Value);
            return new Instruction(turn, magnitude);
        }

        public Position ApplyInstructions(Position position, List<Instruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                position = ApplyInstruction(position, instruction);
                Console.WriteLine("Moved {0} to {1}", instruction, position);
            }

            return position;
        }

        public Position ApplyInstruction(Position position, Instruction instruction)
        {
            return ApplyMagnitude(ApplyTurn(position, instruction.turn), instruction.magnitude);
        }

        public Position ApplyMagnitude(Position position, int magnitude)
        {
            int x = position.x;
            int y = position.y;

            switch (position.facing)
            {
                case Direction.North:
                    y += magnitude;
                    break;
                case Direction.South:
                    y -= magnitude;
                    break;
                case Direction.East:
                    x += magnitude;
                    break;
                case Direction.West:
                    x -= magnitude;
                    break;
                default:
                    break;
            }

            return new Position(x, y, position.facing);
        }

        public Position ApplyTurn(Position position, Turn turn)
        {
            Direction facing = Direction.North;

            switch (position.facing)
            {
                case Direction.North:
                    facing = ApplyTurn(turn, Direction.West, Direction.East);
                    break;
                case Direction.South:
                    facing = ApplyTurn(turn, Direction.East, Direction.West);
                    break;
                case Direction.East:
                    facing = ApplyTurn(turn, Direction.North, Direction.South);
                    break;
                case Direction.West:
                    facing = ApplyTurn(turn, Direction.South, Direction.North);
                    break;
                default:
                    facing = Direction.North;
                    break;
            }

            return new Position(position.x, position.y, facing);
        }

        public Direction ApplyTurn(Turn turn, Direction left, Direction right)
        {
            if (Turn.L == turn)
            {
                return left;
            }
            else //Turn.R == turn
            {
                return right;
            }
        }

        public override string ToString()
        {
            return "Day 1 - Easter Navigation";
        }
    }
}
