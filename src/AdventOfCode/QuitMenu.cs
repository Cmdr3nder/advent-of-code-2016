using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class QuitMenu : IProgram
    {
        public Control Run()
        {
            return Control.Quit;
        }

        public override string ToString()
        {
            return "Quit";
        }
    }
}
