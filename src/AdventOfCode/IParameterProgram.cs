using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public interface IParameterProgram<P>
    {
        Control Run(P param);
    }
}
