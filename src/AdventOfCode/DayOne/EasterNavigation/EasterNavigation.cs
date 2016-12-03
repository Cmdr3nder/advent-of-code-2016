using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using AdventOfCode.Utils;

namespace AdventOfCode.DayOne.EasterNavigation
{
    public class EasterNavigation : IProgram, IParameterProgram<string>
    {
        public Control Run()
        {
            var batches = new List<IProgram>();
            batches.Add(new InputBatch<string>(this, "R2, L3"));
            batches.Add(new InputBatch<string>(this, "R2, R2, R2"));
            batches.Add(new InputBatch<string>(this, "R5, L5, R5, R3"));
            batches.Add(new InputBatch<string>(this, "L5, R1, R4, L5, L4, R3, R1, L1, R4, R5, L1, L3, R4, L2, L4, R2, L4, L1, R3, R1, R1, L1, R1, L5, R5, R2, L5, R2, R1, L2, L4, L4, R191, R2, R5, R1, L1, L2, R5, L2, L3, R4, L1, L1, R1, R50, L1, R1, R76, R5, R4, R2, L5, L3, L5, R2, R1, L1, R2, L3, R4, R2, L1, L1, R4, L1, L1, R185, R1, L5, L4, L5, L3, R2, R3, R1, L5, R1, L3, L2, L2, R5, L1, L1, L3, R1, R4, L2, L1, L1, L3, L4, R5, L2, R3, R5, R1, L4, R5, L3, R3, R3, R1, R1, R5, R2, L2, R5, L5, L4, R4, R3, R5, R1, L3, R1, L2, L2, R3, R4, L1, R4, L1, R4, R3, L1, L4, L1, L5, L2, R2, L1, R1, L5, L3, R4, L1, R5, L5, L5, L1, L3, R1, R5, L2, L4, L5, L1, L1, L2, R5, R5, L4, R3, L2, L1, L3, L4, L5, L5, L2, R4, R3, L5, R4, R2, R1, L5"));
            var menu = new MenuRunner("Select Input Batch", "Select Input Batch:", batches);
            return menu.Run();
        }

        public Control Run(string instructions)
        {
            var position = new Position(0, 0, Cardinal.North);
            var positions = new List<Position>();
            positions.Add(position);
            position = ApplyInstructions(position, ConvertInstructions(instructions), positions);

            var blocks = BlocksFromOrigin(position);
            Console.WriteLine("You are {0} blocks from your drop point.", blocks);

            position = FindRepeatPosition(positions);
            blocks = BlocksFromOrigin(position);
            Console.WriteLine("First duplicated position is {0}, which is {1} blocks from your drop point.", position, blocks);

            return Control.Continue;
        }

        public int BlocksFromOrigin(Position position)
        {
            return Math.Abs(position.x) + Math.Abs(position.y);
        }

        public Position FindRepeatPosition(List<Position> positions)
        {
            var visited = new HashSet<Position>();
            Position duplicate = null;

            for (int i = 0; i < positions.Count && duplicate == null; ++i)
            {
                duplicate = new Position(positions[i].x, positions[i].y, Cardinal.North);

                if (!visited.Contains(duplicate))
                {
                    visited.Add(duplicate);
                    duplicate = null;
                }
            }

            return duplicate;
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
            var regex = new Regex("(?<turn>L|R)(?<magnitude>[0-9]*)", RegexOptions.ExplicitCapture);
            Match match = regex.Match(str);
            var turn = (match.Groups["turn"].Value == "L" ? Turn.L : Turn.R);
            var magnitude = int.Parse(match.Groups["magnitude"].Value);
            return new Instruction(turn, magnitude);
        }

        public Position ApplyInstructions(Position position, List<Instruction> instructions, List<Position> positions = null)
        {
            foreach (var instruction in instructions)
            {
                var prev = position;
                position = ApplyInstruction(position, instruction);
                if (positions != null)
                {
                    AddPositions(prev, position, positions);
                    positions.Add(position);
                }
                Console.WriteLine("Moved {0} to {1}", instruction, position);
            }

            return position;
        }

        public void AddPositions(Position a, Position b, List<Position> positions)
        {
            if (a.x == b.x)
            {
                var max = Math.Max(a.y, b.y);
                var min = Math.Min(a.y, b.y);
                for (int y = min + 1; y < max; ++y)
                {
                    positions.Add(new Position(a.x, y, Cardinal.North));
                }
            }
            else if (a.y == b.y)
            {
                var max = Math.Max(a.x, b.x);
                var min = Math.Min(a.x, b.x);
                for (int x = min + 1; x < max; ++x)
                {
                    positions.Add(new Position(x, a.y, Cardinal.North));
                }
            }
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
                case Cardinal.North:
                    y += magnitude;
                    break;
                case Cardinal.South:
                    y -= magnitude;
                    break;
                case Cardinal.East:
                    x += magnitude;
                    break;
                case Cardinal.West:
                    x -= magnitude;
                    break;
                default:
                    break;
            }

            return new Position(x, y, position.facing);
        }

        public Position ApplyTurn(Position position, Turn turn)
        {
            Cardinal facing = Cardinal.North;

            switch (position.facing)
            {
                case Cardinal.North:
                    facing = ApplyTurn(turn, Cardinal.West, Cardinal.East);
                    break;
                case Cardinal.South:
                    facing = ApplyTurn(turn, Cardinal.East, Cardinal.West);
                    break;
                case Cardinal.East:
                    facing = ApplyTurn(turn, Cardinal.North, Cardinal.South);
                    break;
                case Cardinal.West:
                    facing = ApplyTurn(turn, Cardinal.South, Cardinal.North);
                    break;
                default:
                    facing = Cardinal.North;
                    break;
            }

            return new Position(position.x, position.y, facing);
        }

        public Cardinal ApplyTurn(Turn turn, Cardinal left, Cardinal right)
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
            return "Day 1: No Time for a Taxicab";
        }
    }
}
