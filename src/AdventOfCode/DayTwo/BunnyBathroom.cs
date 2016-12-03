using System;
using System.Text;
using System.Collections.Generic;
using AdventOfCode.Utils;
using Pad = AdventOfCode.Utils.NamedValue<AdventOfCode.DayTwo.Key[,]>;

namespace AdventOfCode.DayTwo
{
    public class BunnyBathroom : IProgram
    {
        private static readonly string MANUAL_INPUT = "Manual";

        public Control Run()
        {
            var input = InputOptions().Ask();
            if (input == MANUAL_INPUT)
            {
                input = ManualInput().Ask().Trim();
            }
            Console.WriteLine("Input: {0}", input);

            var pad = PadOptions().Ask().value;

            PrintCode(GenerateCode(input, pad, Key.Five));

            return Control.Continue;
        }

        private Menu<string> InputOptions()
        {
            var options = new List<string>();
            options.Add("DDDURLURURUDLDURRURULLRRDULRRLRLRURDLRRDUDRUDLRDUUDRRUDLLLURLUURLRURURLRLUDDURUULDURDRUUDLLDDDRLDUULLUDURRLUULUULDLDDULRLDLURURUULRURDULLLURLDRDULLULRRRLRLRULLULRULUUULRLLURURDLLRURRUUUDURRDLURUURDDLRRLUURLRRULURRDDRDULLLDRDDDDURURLLULDDULLRLDRLRRDLLURLRRUDDDRDLLRUDLLLLRLLRUDDLUUDRLRRRDRLRDLRRULRUUDUUDULLRLUDLLDDLLDLUDRURLULDLRDDLDRUDLDDLDDDRLLDUURRUUDLLULLRLDLUURRLLDRDLRRRRUUUURLUUUULRRUDDUDDRLDDURLRLRLLRRUDRDLRLDRRRRRRUDDURUUUUDDUDUDU\nRLULUULRDDRLULRDDLRDUURLRUDDDUULUUUDDRDRRRLDUURDURDRLLLRDDRLURLDRRDLRLUURULUURDRRULRULDULDLRRDDRLDRUDUDDUDDRULURLULUDRDUDDDULRRRURLRRDLRDLDLLRLUULURLDRURRRLLURRRRRLLULRRRDDLRLDDUULDLLRDDRLLUUDRURLRULULRLRUULUUUUUDRURLURLDDUDDLRDDLDRRLDLURULUUDRDLULLURDLLLRRDRURUDDURRLURRDURURDLRUDRULUULLDRLRRDRLDDUDRDLLRURURLUDUURUULDURUDULRLRDLDURRLLDRDUDRUDDRLRURUDDLRRDLLLDULRRDRDRRRLURLDLURRDULDURUUUDURLDLRURRDRULLDDLLLRUULLLLURRRLLLDRRUDDDLURLRRRDRLRDLUUUDDRULLUULDURLDUUURUDRURUDRDLRRLDRURRLRDDLLLULUDDUULDURLRUDRDDD\nRDDRUDLRLDDDRLRRLRRLUULDRLRUUURULRRLUURLLLRLULDDLDLRLULULUUDDDRLLLUDLLRUDURUDDLLDUDLURRULLRDLDURULRLDRLDLDRDDRUDRUULLLLRULULLLDDDULUUDUUDDLDRLRRDLRLURRLLDRLDLDLULRLRDLDLRLUULLDLULRRRDDRUULDUDLUUUUDUDRLUURDURRULLDRURUDURDUULRRULUULULRLDRLRLLRRRLULURLUDULLDRLDRDRULLUUUDLDUUUDLRDULRDDDDDDDDLLRDULLUDRDDRURUDDLURRUULUURURDUDLLRRRRDUDLURLLURURLRDLDUUDRURULRDURDLDRUDLRRLDLDULRRUDRDUUDRLURUURLDLUDLLRDDRDU\nLLDDDDLUDLLDUDURRURLLLLRLRRLDULLURULDULDLDLLDRRDLUDRULLRUUURDRLLURDDLLUDDLRLLRDDLULRLDDRURLUDRDULLRUDDLUURULUUURURLRULRLDLDDLRDLDLLRUURDLUDRRRDDRDRLLUDDRLDRLLLRULRDLLRLRRDDLDRDDDUDUDLUULDLDUDDLRLDUULRULDLDULDDRRLUUURUUUDLRDRULDRRLLURRRDUDULDUDUDULLULLULULURLLRRLDULDULDLRDDRRLRDRLDRLUDLLLUULLRLLRLDRDDRUDDRLLDDLRULLLULRDDDLLLDRDLRULDDDLULURDULRLDRLULDDLRUDDUDLDDDUDRDRULULDDLDLRRDURLLRLLDDURRLRRULLURLRUDDLUURULULURLRUDLLLUDDURRLURLLRLLRRLDULRRUDURLLDDRLDLRRLULUULRRUURRRDULRLRLRDDRDULULUUDULLLLURULURRUDRLL\nUULLULRUULUUUUDDRULLRLDDLRLDDLULURDDLULURDRULUURDLLUDDLDRLUDLLRUURRUDRLDRDDRRLLRULDLLRUUULLLDLDDULDRLRURLDRDUURLURDRUURUULURLRLRRURLDDDLLDDLDDDULRUDLURULLDDRLDLUDURLLLLLRULRRLLUDRUURLLURRLLRDRLLLRRDDDRRRDLRDRDUDDRLLRRDRLRLDDDLURUUUUULDULDRRRRLUDRLRDRUDUDDRULDULULDRUUDUULLUDULRLRRURDLDDUDDRDULLUURLDRDLDDUURULRDLUDDLDURUDRRRDUDRRDRLRLULDRDRLRLRRUDLLLDDDRURDRLRUDRRDDLDRRLRRDLUURLRDRRUDRRDLDDDLRDDLRDUUURRRUULLDDDLLRLDRRLLDDRLRRRLUDLRURULLDULLLUDLDLRLLDDRDRUDLRRDDLUU");
            options.Add("UUL\nRRDDD\nLURDL\nUUUUD");
            options.Add(MANUAL_INPUT);
            return new Menu<string>("Select Input:", options);
        }

        private MultiLineRead ManualInput()
        {
            return new MultiLineRead("Please input the instructions:");
        }

        private Menu<Pad> PadOptions()
        {
            var options = new List<Pad>();
            options.Add(new Pad("9-key", new Key[,] {
                {Key.One, Key.Two, Key.Three},
                {Key.Four, Key.Five, Key.Six},
                {Key.Seven, Key.Eight, Key.Nine}
            }));
            options.Add(new Pad("Star", new Key[,] {
                {Key.Empty, Key.Empty, Key.One, Key.Empty, Key.Empty},
                {Key.Empty, Key.Two, Key.Three, Key.Four, Key.Empty},
                {Key.Five, Key.Six, Key.Seven, Key.Eight, Key.Nine},
                {Key.Empty, Key.A, Key.B, Key.C, Key.Empty},
                {Key.Empty, Key.Empty, Key.D, Key.Empty, Key.Empty}
            }));
            return new Menu<Pad>("Select Pad:", options);
        }

        public List<Key> GenerateCode(string input, Key[,] pad, Key start)
        {
            var coord = FindFirst(start, pad);
            var code = new List<Key>();
            var key = Key.Five;
            foreach (var ch in input)
            {
                switch (ch)
                {
                    case 'U':
                        coord = Move(coord, Utils.Direction.Up, pad);
                        key = GetKey(coord, pad);
                        break;
                    case 'D':
                        coord = Move(coord, Utils.Direction.Down, pad);
                        key = GetKey(coord, pad);
                        break;
                    case 'L':
                        coord = Move(coord, Utils.Direction.Left, pad);
                        key = GetKey(coord, pad);
                        break;
                    case 'R':
                        coord = Move(coord, Utils.Direction.Right, pad);
                        key = GetKey(coord, pad);
                        break;
                    case '\n':
                        code.Add(key);
                        break;
                    default:
                        break;
                }
            }
            code.Add(key); //Add code from end of input.
            return code;
        }

        public Coordinate Move(Coordinate coord, Direction direction, Key[,] pad)
        {
            var next = Move(coord, direction);
            var key = GetKey(next, pad);

            if (key != Key.Empty)
            {
                return next;
            }

            return coord;
        }

        public Coordinate Move(Coordinate coord, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return new Coordinate(coord.x, coord.y - 1);
                case Direction.Down:
                    return new Coordinate(coord.x, coord.y + 1);
                case Direction.Left:
                    return new Coordinate(coord.x - 1, coord.y);
                case Direction.Right:
                    return new Coordinate(coord.x + 1, coord.y);
                default:
                    return coord;
            }
        }

        public Key GetKey(Coordinate coord, Key[,] pad)
        {
            if (coord.x < pad.GetLength(1) && coord.x >= 0 && coord.y < pad.GetLength(0) && coord.y >= 0)
            {
                return pad[coord.y, coord.x];
            }

            return Key.Empty;
        }

        public Coordinate FindFirst(Key key, Key[,] pad)
        {
            Coordinate res = null;

            for (int y = 0; y < pad.GetLength(0) && res == null; ++ y)
            {
                for (int x = 0; x < pad.GetLength(1) && res == null; ++x)
                {
                    if (pad[y, x] == key)
                    {
                        res = new Coordinate(x, y);
                    }
                }
            }

            return res;
        }

        private void PrintCode(List<Key> code)
        {
            var codeStr = new StringBuilder();
            foreach (Key key in code)
            {
                var keyVal = (int)key;
                if (keyVal < 10)
                {
                    codeStr.Append(keyVal);
                }
                else
                {
                    codeStr.Append(key);
                }
            }
            Console.WriteLine("The bathroom code is: {0}", codeStr);
        }

        public override string ToString()
        {
            return "Day 2: Bathroom Security";
        }
    }
}
