namespace BattleshipGameApi.Models
{
    public class GameBoard
    {
        public const int BoardSize = 10;
        public string[,] Grid { get; set; } = new string[BoardSize, BoardSize];
        public List<Ship> Ships { get; set; } = new List<Ship>();

        public GameBoard()
        {
            InitializeBoard();
        }

        public void InitializeBoard()
        {
            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    Grid[row, col] = "E";  // E for Empty
                }
            }
        }

        public bool PlaceShip(Ship ship)
        {
            Random random = new Random();
            bool placed = false;

            while (!placed)
            {
                int row = random.Next(BoardSize);
                int col = random.Next(BoardSize);
                bool horizontal = random.Next(2) == 0;  // Randomly choose direction

                if (CanPlaceShip(ship, row, col, horizontal))
                {
                    for (int i = 0; i < ship.Size; i++)
                    {
                        if (horizontal)
                        {
                            Grid[row, col + i] = "S";  // S for Ship
                            ship.Positions.Add((row, col + i));
                        }
                        else
                        {
                            Grid[row + i, col] = "S";
                            ship.Positions.Add((row + i, col));
                        }
                    }
                    Ships.Add(ship);
                    placed = true;
                }
            }

            return placed;
        }

        private bool CanPlaceShip(Ship ship, int row, int col, bool horizontal)
        {
            if (horizontal && col + ship.Size > BoardSize)
                return false;
            if (!horizontal && row + ship.Size > BoardSize)
                return false;

            for (int i = 0; i < ship.Size; i++)
            {
                if (horizontal && Grid[row, col + i] != "E")
                    return false;
                if (!horizontal && Grid[row + i, col] != "E")
                    return false;
            }

            return true;
        }

        public string FireShot(int row, int col)
        {
            if (Grid[row, col] == "S")
            {
                Grid[row, col] = "H";  // H for Hit
                var ship = Ships.FirstOrDefault(s => s.Positions.Contains((row, col)));
                if (ship != null)
                {
                    ship.Hits++;
                    return ship.IsSunk ? "sunk" : "hit";
                }
            }
            else if (Grid[row, col] == "E")
            {
                Grid[row, col] = "M";  // M for Miss
                return "miss";
            }

            return "invalid";
        }

        public bool IsGameOver()
        {
            return Ships.All(ship => ship.IsSunk);
        }
    }
}