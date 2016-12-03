using System;
using System.Collections.Generic;

namespace AdventOfCode.Utils
{
    public class Menu<R>
    {
        private List<R> options;
        private string header;
        private int max;

        public Menu(string header, List<R> options, int max = 40)
        {
            this.header = header;
            this.options = options;
            this.max = max;
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
                string opt = options[i].ToString().Replace("\n", "\\n");
                opt = opt.Length <= max ? opt : string.Format("{0}...", opt.Substring(0, max - 3));
                Console.WriteLine("{0}) {1}", i + 1, opt);
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
