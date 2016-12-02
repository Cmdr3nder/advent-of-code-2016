using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.DayOne.EasterNavigation
{
    public class InputBatch : IProgram
    {
        private EasterNavigation parent;
        private string instructions;

        public InputBatch(EasterNavigation parent, string instructions)
        {
            this.parent = parent;
            this.instructions = instructions;
        }

        public override string ToString()
        {
            return instructions.Length <= 20 ? instructions : string.Format("{0}...", instructions.Substring(0, 17));
        }

        public Control Run()
        {
            return parent.RunBatch(instructions);
        }
    }
}
