namespace AdventOfCode.DaySeven
{
    public class AddressPart
    {
        private static readonly string PLAIN = "{0}";
        private static readonly string HYPERNET = "[{0}]";

        public AddressPart(string value, bool hypernet)
        {
            this.value = value;
            this.hypernet = hypernet;
        }

        public string value { get; }
        public bool hypernet { get; }

        public override string ToString()
        {
            return string.Format((hypernet ? HYPERNET : PLAIN), value);
        }
    }
}