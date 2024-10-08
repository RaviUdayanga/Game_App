namespace BattleshipGameApi.Models
{
    public class Ship
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public int Hits { get; set; }
        public List<(int, int)> Positions { get; set; } = new List<(int, int)>();

        public bool IsSunk => Hits >= Size;
    }
}