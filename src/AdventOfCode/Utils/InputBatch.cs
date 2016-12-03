namespace AdventOfCode.Utils
{
    public class InputBatch<P> : IProgram
    {
        private IParameterProgram<P> program;
        private P parameter;

        public InputBatch(IParameterProgram<P> program, P parameter)
        {
            this.program = program;
            this.parameter = parameter;
        }
        
        public override string ToString()
        {
            string param = parameter.ToString().Replace("\n", "\\n");
            return param.Length <= 20 ? param : string.Format("{0}...", param.ToString().Substring(0, 17));
        }

        public Control Run()
        {
            return program.Run(parameter);
        }
    }
}
