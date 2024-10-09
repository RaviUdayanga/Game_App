using BattleshipGameAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BattleshipGameAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BattleshipController : ControllerBase
    {
        private readonly Game _game;

        public BattleshipController()
        {
            _game = new Game(); // Ideally, you should use Dependency Injection to manage state
        }

        [HttpPost("start")]
        public IActionResult StartGame()
        {
            return Ok(new { message = "Game started!", gridSize = _game.Grid.Size });
        }

        [HttpPost("fire")]
        public IActionResult FireShot([FromBody] FireShotRequest request)
        {
            var result = _game.FireShot(request.X, request.Y);
            return Ok(result);
        }

        //[HttpGet("state")]
        //public IActionResult GetGameState()
        //{
        //    return Ok(new { shipsRemaining = _game.Ships.Count, grid = _game.Grid.Cells });
        //}

        //[HttpGet("state")]
        //public IActionResult GetGameState()
        //{
        //    var game = new Game();
        //    // Populate game.Board with your game logic

        //    return Ok(game); // Return the game object with the jagged array
        //}

        [HttpGet("state")]
        public IActionResult GetGameState()
        {
            var grid = new Grid();
            // Populate grid.Cells with your game logic
            return Ok(grid); // Return the grid object
        }
    }
}
