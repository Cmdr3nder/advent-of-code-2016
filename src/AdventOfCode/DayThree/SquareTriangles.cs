using AdventOfCode.Utils;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode.DayThree
{
    public class SquareTriangles : IProgram
    {
        private static readonly Triangle ZERO = new Triangle(0, 0, 0);

        public Control Run()
        {
            var input = new MultiLineRead("Please input the sequence of triangles:");
            var triangleStr = input.Ask().Trim();
            var triangles = ConvertTriangles(triangleStr);
            WriteValidCount(triangles);
            WriteValidCount(VerticalTriangles(triangles), " Vertical ");
            return Control.Continue;
        }

        public List<Triangle> ConvertTriangles(string input)
        {
            var regex = new Regex("(?<a>[0-9]+)\\s*(?<b>[0-9]+)\\s*(?<c>[0-9]+)", RegexOptions.ExplicitCapture);
            var matches = regex.Matches(input);
            var triangles = new List<Triangle>();

            foreach (Match match in matches)
            {
                uint a = uint.Parse(match.Groups["a"].Value);
                uint b = uint.Parse(match.Groups["b"].Value);
                uint c = uint.Parse(match.Groups["c"].Value);
                triangles.Add(new Triangle(a, b, c));
            }

            return triangles;
        }

        public List<Triangle> VerticalTriangles(List<Triangle> triangles)
        {
            var result = new List<Triangle>();

            for (int i = 0; i < triangles.Count; i += 3)
            {
                var tri1 = SafeGet(triangles, i + 0);
                var tri2 = SafeGet(triangles, i + 1);
                var tri3 = SafeGet(triangles, i + 2);
                result.Add(new Triangle(tri1.a, tri2.a, tri3.a));
                result.Add(new Triangle(tri1.b, tri2.b, tri3.b));
                result.Add(new Triangle(tri1.c, tri2.c, tri3.c));
            }

            return result;
        }

        private Triangle SafeGet(List<Triangle> triangles, int index)
        {
            if (index < triangles.Count && index >= 0)
            {
                return triangles[index];
            }

            return ZERO;
        }

        private void WriteValidCount(List<Triangle> triangles, string extra = "")
        {
            uint countValid = 0;
            foreach (var triangle in triangles)
            {
                if (triangle.valid)
                {
                    countValid++;
                }
            }
            Console.WriteLine("Valid Triangle Count{2}: {0} of {1}", countValid, triangles.Count, extra);
        }

        public override string ToString()
        {
            return "Day 3: Squares With Three Sides";
        }
    }
}
