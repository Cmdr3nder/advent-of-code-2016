namespace AdventOfCode.DayOne.EasterNavigation
{
    public class Instruction
    {
        public Instruction(Turn turn, int magnitude)
        {
            this.turn = turn;
            this.magnitude = magnitude;
        }

        public int magnitude { get; }
        public Turn turn { get; }

        public override string ToString()
        {
            return string.Format("{0}{1}", turn, magnitude);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Instruction i = obj as Instruction;
            if ((object)i == null)
            {
                return false;
            }

            return turn == i.turn && magnitude == i.magnitude;
        }

        public override int GetHashCode()
        {
            return magnitude ^ (int)turn;
        }

        public static bool operator ==(Instruction a, Instruction b)
        {
            if (object.ReferenceEquals(a, b))
            {
                return true;
            }

            if ((object)a == null || (object)b == null)
            {
                return false;
            }

            return a.magnitude == b.magnitude && a.turn == b.turn;
        }

        public static bool operator !=(Instruction a, Instruction b)
        {
            return !(a == b);
        }
    }
}
