using AdventOfCode.Utils;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;

namespace AdventOfCode.DaySeven
{
    public class IPV7 : IProgram
    {
        public IPV7()
        {
            this.regex = new Regex("(?:<part>\\[?([a-z]+)\\]?)", RegexOptions.ExplicitCapture);
        }

        private readonly Regex regex;

        public Control Run()
        {
            //var input = (new MultiLineRead("Please input the IPv7 Addresses:")).Ask().Trim();
            //var addresses = BuildAddresses(input);
            //Console.WriteLine("First Address: {0}", string.Join("", addresses[0]));
            var input = (new WebRead("IPv7 Addresses")).Ask();
            Console.WriteLine(input);

            return Control.Continue;
        }

        public List<List<AddressPart>> BuildAddresses(string input)
        {
            var addresses = new List<List<AddressPart>>();

            foreach (var line in input.Split('\n'))
            {
                addresses.Add(BuildAddress(line));
            }

            return addresses;
        }

        public List<AddressPart> BuildAddress(string input)
        {
            var parts = new List<AddressPart>();
            foreach (Match match in regex.Matches(input.Trim()))
            {
                var value = match.Groups["part"].Value;
                bool hypernet = value.StartsWith("[") && value.EndsWith("]");
                if (hypernet)
                {
                    value = value.Substring(1, value.Length - 2);
                }
                parts.Add(new AddressPart(value, hypernet));
            }
            return parts;
        }

        public override string ToString()
        {
            return "Day 7: Internet Protocol Version 7";
        }
    }
}