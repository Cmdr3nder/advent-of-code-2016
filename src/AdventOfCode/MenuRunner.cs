using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class MenuRunner : IProgram
    {
        private List<IProgram> options;
        private string header;
        private string title;

        public MenuRunner(string title, string header, List<IProgram> options)
        {
            this.title = title;
            this.header = header;
            this.options = options;
        }

        public Control Run()
        {
            var menu = new Menu<IProgram>(header, options);
            return menu.Ask().Run();
        }

        public override string ToString()
        {
            return title;
        }
    }
}
