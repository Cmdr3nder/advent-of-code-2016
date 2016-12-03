using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Menu<R>
    {
        private List<R> options;
        private string header;

        public Menu(string header, List<R> options)
        {
            this.header = header;
            this.options = options;
        }

        public R Ask()
        {
            Render();
            int sel = Selection();
            return options[sel];
        }

        private void Render()
        {
            Console.WriteLine(header);
            for (int i = 0; i < options.Count; ++i)
            {
                Console.WriteLine("{0}) {1}", i + 1, options[i]);
            }
        }

        private int Selection()
        {
            int sel = 0;
            while (sel == 0)
            {
                Console.Write("> ");
                string selection = Console.ReadLine();

                if (!int.TryParse(selection, out sel))
                {
                    sel = 0;
                }
                else if (sel < 1 || sel > options.Count)
                {
                    sel = 0;
                }
            }
            return sel - 1;
        }
    }
}
