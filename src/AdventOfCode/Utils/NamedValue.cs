namespace AdventOfCode.Utils
{
    public class NamedValue<V>
    {
        private string name;

        public NamedValue(string name, V value)
        {
            this.value = value;
            this.name = name;
        }

        public V value { get; }

        public override string ToString()
        {
            return name;
        }
    }
}
