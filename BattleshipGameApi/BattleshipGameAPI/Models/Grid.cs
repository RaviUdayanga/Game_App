namespace BattleshipGameAPI.Models
{
    public class Grid
    {
        //public int[,] Cells { get; set; }
        public int[][] Cells { get; set; }
        public int Size { get; set; } = 10;

        public Grid()
        {
            //Cells = new int[Size, Size]; // 0 = empty, 1 = ship, -1 = hit
            Cells = new int[10][]; // Initialize jagged array
            for (int i = 0; i < 10; i++)
            {
                Cells[i] = new int[10]; // Initialize each row
            }
        }

        public void PlaceShipsRandomly(List<Ship> ships)
        {
            // Randomly place ships on the grid
        }
    }
}
