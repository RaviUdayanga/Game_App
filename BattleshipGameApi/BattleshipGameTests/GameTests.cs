using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleshipGameAPI.Models;

namespace BattleshipGameTests
{
    public class GameTests
    {
        [Fact]
        public void FireShot_ShouldReturnHit_WhenShipIsHit()
        {
            // Arrange
            var game = new Game();

            // Simulate a ship placed at 0,0 (you may need to adjust according to your logic)
            game.Ships[0].Coordinates.Add((0, 2));

            // Act
            var result = game.FireShot(0, 0);

            // Assert
            Assert.Equal("Hit", result);
        }

        [Fact]
        public void FireShot_ShouldReturnMiss_WhenNoShipAtLocation()
        {
            // Arrange
            var game = new Game();

            // Act
            var result = game.FireShot(5, 5);

            // Assert
            Assert.Equal("Miss", result);
        }

        [Fact]
        public void FireShot_ShouldReturnInvalid_WhenCoordinatesOutOfBounds()
        {
            // Arrange
            var game = new Game();

            // Act
            var result = game.FireShot(-1, 10);  // Out of bounds

            // Assert
            Assert.Equal("Invalid coordinates", result);
        }
    }
}
