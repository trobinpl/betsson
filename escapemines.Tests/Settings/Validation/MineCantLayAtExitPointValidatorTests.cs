using escapemines.Game;
using escapemines.Game.Settings.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace escapemines.Tests.Settings.Validation
{
    [TestClass]
    public class MineCantLayAtExitPointValidatorTests
    {
        [TestMethod]
        public void Validates()
        {
            var correctSettings = new GameSettings(5, 4, new HashSet<Coordinate>() { new Coordinate(1, 2), new Coordinate(3, 2) }, new Coordinate(3, 3), new Coordinate(2, 1), Direction.N, new List<List<GameAction>>() { new List<GameAction>() { GameAction.Move } });
            var incorrectSettings = new GameSettings(5, 4, new HashSet<Coordinate>() { new Coordinate(3, 3) }, new Coordinate(3, 3), new Coordinate(2, 1), Direction.N, new List<List<GameAction>>());

            var validator = new MineCantLayAtExitPointValidator();

            Assert.IsTrue(validator.Validate(correctSettings));
            Assert.IsFalse(validator.Validate(incorrectSettings));
        }
    }
}
