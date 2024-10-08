using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private static readonly char[,] GameGrid = new char[10, 10];

    public GameController()
    {
        // Initialize grid and randomly place ships (Battleship: 5 squares, Destroyers: 2x4 squares)
        InitializeGrid();
    }

    [HttpPost("fireShot")]
    public IActionResult FireShot([FromBody] FireShotRequest request)
    {
        // Extract coordinates
        var (row, col) = ConvertCoordinates(request.Coordinates);

        // Check if the shot is a hit or miss and return the result
        if (GameGrid[row, col] == 'S') // 'S' represents a ship
        {
            GameGrid[row, col] = 'H'; // 'H' represents a hit
            return Ok(new { result = "Hit", coordinates = request.Coordinates });
        }
        else
        {
            return Ok(new { result = "Miss", coordinates = request.Coordinates });
        }
    }

    private void InitializeGrid()
    {
        // For simplicity, placing ships manually (this should be random in a real implementation)
        for (int i = 0; i < 5; i++) GameGrid[0, i] = 'S'; // Battleship (5 squares on row 1)
        for (int i = 0; i < 4; i++) GameGrid[2, i] = 'S'; // Destroyer 1 (4 squares on row 3)
        for (int i = 0; i < 4; i++) GameGrid[4, i] = 'S'; // Destroyer 2 (4 squares on row 5)
    }

    private (int, int) ConvertCoordinates(string input)
    {
        // Convert input like "A5" into row and column (e.g., A5 -> (0, 4))
        int row = input[0] - 'A';
        int col = int.Parse(input[1..]) - 1;
        return (row, col);
    }
}

public class FireShotRequest
{
    public string Coordinates { get; set; } // Example: "A5"
}