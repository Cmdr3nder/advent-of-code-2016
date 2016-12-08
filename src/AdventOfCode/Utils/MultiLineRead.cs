using System;
using System.Text;

namespace AdventOfCode.Utils
{
    public class MultiLineRead
    {
        private readonly string header;

        public MultiLineRead(string header)
        {
            this.header = header;
        }

        public string Ask()
        {
            Console.WriteLine("{0}\nPress <Escape> to complete entry", header);
            var result = new StringBuilder();
            var last = Console.ReadKey();

            while (last.Key != ConsoleKey.Escape)
            {
                var ch = ToChar(last);
                result.Append(ch);
                last = Console.ReadKey();
            }

            Console.WriteLine();
            return result.ToString();
        }

        private char ToChar(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.Enter)
            {
                return '\n';
            }
            else
            {
                return key.KeyChar;
            }
        }
    }
}
