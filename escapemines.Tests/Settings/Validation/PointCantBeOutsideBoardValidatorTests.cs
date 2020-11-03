using escapemines.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using escapemines.Game.Settings.Validation;

namespace escapemines.Tests.Settings.Validation
{
    [TestClass]
    public class PointCantBeOutsideBoardValidatorTests
    {
        [TestMethod]
        public void Validates()
        {
            var correctSettings = new GameSettings(5, 4, new HashSet<Coordinate>() { new Coordinate(1, 2), new Coordinate(3, 2) }, new Coordinate(3, 3), new Coordinate(2, 1), Direction.N, new List<List<GameAction>>() { new List<GameAction>() { GameAction.Move } });
            var incorrectSettings = new GameSettings(5, 4, new HashSet<Coordinate>() { }, new Coordinate(3, 5), new Coordinate(4, 1), Direction.N, new List<List<GameAction>>());

            var startingPointValidator = new PointCantBeOutsideOfBoardValidator(s => s.StartingPoint);
            var exitPointValidator = new PointCantBeOutsideOfBoardValidator(s => s.ExitPoint);

            Assert.IsTrue(startingPointValidator.Validate(correctSettings));
            Assert.IsTrue(exitPointValidator.Validate(correctSettings));
            Assert.IsFalse(startingPointValidator.Validate(incorrectSettings));
            Assert.IsFalse(exitPointValidator.Validate(incorrectSettings));
        }
    }
}
