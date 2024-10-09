namespace BattleshipGameAPI.Models
{
    public class Ship
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public List<(int X, int Y)> Coordinates { get; set; } // Stores ship's coordinates

        public Ship(string name, int size)
        {
            Name = name;
            Size = size;
            Coordinates = new List<(int, int)>();
        }
    }
}
