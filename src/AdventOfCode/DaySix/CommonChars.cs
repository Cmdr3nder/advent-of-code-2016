using AdventOfCode.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.DaySix
{
    public class CommonChars : IProgram
    {
        public Control Run()
        {
            var input = (new MultiLineRead("Input repitition code:")).Ask().Trim();

            var counts = ProcessRepetition(input);
            Console.WriteLine("Repeat, repeat: {0}", MostCommonMessage(counts));
            Console.WriteLine("Repeat, less: {0}", LeastCommonMessage(counts));

            return Control.Continue;
        }

        public List<Dictionary<char, uint>> ProcessRepetition(string input)
        {
            var regex = new Regex("(?<value>.+)\n");
            var matches = regex.Matches(input);
            var counts = new List<Dictionary<char, uint>>();

            foreach (Match match in matches)
            {
                var str = match.Groups["value"].Value;

                while (counts.Count < str.Length)
                {
                    counts.Add(new Dictionary<char, uint>());
                }

                for (int i = 0; i < str.Length; ++i)
                {
                    if (!counts[i].ContainsKey(str[i]))
                    {
                        counts[i][str[i]] = 0;
                    }

                    counts[i][str[i]]++;
                }
            }

            return counts;
        }

        public string MostCommonMessage(List<Dictionary<char, uint>> counts)
        {
            var msg = new StringBuilder();
            foreach (var count in counts)
            {
                msg.Append(MostCommon(count));
            }
            return msg.ToString();
        }

        public string LeastCommonMessage(List<Dictionary<char, uint>> counts)
        {
            var msg = new StringBuilder();
            foreach (var count in counts)
            {
                msg.Append(LeastCommon(count));
            }
            return msg.ToString();
        }

        public char LeastCommon(Dictionary<char, uint> counts)
        {
            uint count = uint.MaxValue;
            char ch = ' ';

            foreach (var c in counts)
            {
                if (c.Value < count)
                {
                    ch = c.Key;
                    count = c.Value;
                }
            }

            return ch;
        }

        public char MostCommon(Dictionary<char, uint> counts)
        {
            uint count = 0;
            char ch = ' ';

            foreach (var c in counts)
            {
                if (c.Value > count)
                {
                    ch = c.Key;
                    count = c.Value;
                }
            }

            return ch;
        }

        public override string ToString()
        {
            return "Day 6: Signals and Noise";
        }
    }
}
