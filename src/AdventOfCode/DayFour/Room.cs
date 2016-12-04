namespace AdventOfCode.DayFour
{
    public class Room
    {
        public Room(string name, int sector, string hash)
        {
            this.name = name;
            this.sector = sector;
            this.hash = hash;
        }

        public string name { get; }
        public int sector { get; }
        public string hash { get; }

        public override string ToString()
        {
            return string.Format("{0}-{1}[{2}]", name, sector, hash);
        }
    }
}
