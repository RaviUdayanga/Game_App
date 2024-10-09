namespace BattleshipGameAPI.Models
{
    public class Game
    {
        public Grid Grid { get; set; }
        public List<Ship> Ships { get; set; }

        public Game()
        {
            Grid = new Grid();
            Ships = new List<Ship>
            {
                new Ship("Battleship", 5),
                new Ship("Destroyer1", 4),
                new Ship("Destroyer2", 4)
            };

            Grid.PlaceShipsRandomly(Ships);
        }

        public string FireShot(int x, int y)
        {
            // Check if coordinates are out of bounds
            if (x < 0 || x >= Grid.Size || y < 0 || y >= Grid.Size)
            {
                return "Invalid coordinates"; // Handle invalid coordinates
            }

            // Check if the shot has already been fired at this location
            if (Grid.Cells[x][y] == -1)
            {
                return "Already shot here";
            }

            // Check if it's a hit or miss
            foreach (var ship in Ships)
            {
                if (ship.Coordinates.Contains((x, y)))
                {
                    // Mark as hit
                    Grid.Cells[x][y] = -1;
                    ship.Coordinates.Remove((x, y));

                    // Check if the ship is sunk
                    if (ship.Coordinates.Count == 0)
                    {
                        return $"{ship.Name} sunk!";
                    }

                    return "Hit";
                }
            }

            // If no ships at this location, it's a miss
            Grid.Cells[x][y] = -1;
            return "Miss";
        }
    }
}

