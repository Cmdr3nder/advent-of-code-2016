using AdventOfCode.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.DayFour
{
    public class ObscureSecure : IProgram
    {
        private static readonly string ALPHABET = "abcdefghijklmnopqrstuvwxyz";

        public Control Run()
        {
            var input = (new MultiLineRead("Enter the rooms:")).Ask();
            var rooms = ConvertRooms(input);

            int sectorSum = 0;
            foreach (var room in rooms)
            {
                if (room.hash == HashRoom(room))
                {
                    sectorSum += room.sector;
                    var r = new Room(DecodeName(room), room.sector, room.hash);
                    if (r.name.Contains("north") || r.name.Contains("pole"))
                    {
                        Console.WriteLine(r);
                    }
                }
            }

            Console.WriteLine("The sector sum is {0}.", sectorSum);

            return Control.Continue;
        }

        public List<Room> ConvertRooms(string input)
        {
            var regex = new Regex("(?<name>([a-z]+-)+)(?<sector>[0-9]+)\\[(?<hash>[a-z]+)\\]", RegexOptions.ExplicitCapture);
            var matches = regex.Matches(input);
            var rooms = new List<Room>();

            foreach (Match match in matches)
            {
                string name = match.Groups["name"].Value;
                if (name.EndsWith("-"))
                {
                    name = name.Substring(0, name.Length - 1);
                }

                int sector = int.Parse(match.Groups["sector"].Value);

                string hash = match.Groups["hash"].Value;

                rooms.Add(new Room(name, sector, hash));
            }

            return rooms;
        }

        public string DecodeName(Room room)
        {
            var name = new StringBuilder(room.name.Length);

            foreach (var ch in room.name)
            {
                if (ch == '-')
                {
                    name.Append(' ');
                }
                else
                {
                    var idx = ALPHABET.IndexOf(ch);
                    idx += room.sector;
                    name.Append(ALPHABET[idx % ALPHABET.Length]);
                }
            }

            return name.ToString();
        }

        public string HashRoom(Room room)
        {
            var chCount = new Dictionary<char, int>();

            foreach(var ch in room.name)
            {
                if (ch != '-')
                {
                    if (!chCount.ContainsKey(ch))
                    {
                        chCount.Add(ch, 0);
                    }

                    chCount[ch]++;
                }
            }

            var chs = new List<char>(chCount.Keys);

            chs.Sort((a, b) => {
                if (chCount[a] > chCount[b])
                {
                    return -1;
                }
                else if (chCount[a] < chCount[b])
                {
                    return 1;
                }
                else if (a < b)
                {
                    return -1;
                }
                else if (a > b)
                {
                    return 1;
                }

                return 0;
            });

            return new string(chs.GetRange(0, 5).ToArray());
        }

        private void Shift(char[] chars, int idx)
        {

        }

        public override string ToString()
        {
            return "Day 4: Security Through Obscurity";
        }
    }
}
