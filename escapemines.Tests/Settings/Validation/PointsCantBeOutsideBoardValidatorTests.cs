using escapemines.Game;
using escapemines.Game.Settings.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace escapemines.Tests.Settings.Validation
{
    [TestClass]
    public class PointsCantBeOutsideBoardValidatorTests
    {
        [TestMethod]
        public void Validates()
        {
            var correctSettings = new GameSettings(5, 4, new HashSet<Coordinate>() { new Coordinate(1, 2), new Coordinate(3, 2) }, new Coordinate(3, 3), new Coordinate(2, 1), Direction.N, new List<List<GameAction>>() { new List<GameAction>() { GameAction.Move } });
            var incorrectSettings = new GameSettings(5, 4, new HashSet<Coordinate>() { new Coordinate(3, 5), new Coordinate(0, 1) }, new Coordinate(2, 1), new Coordinate(4, 1), Direction.N, new List<List<GameAction>>());

            var minesPointsValidator = new PointsCantBeOutsideOfBoardValidator(s => s.Mines);

            Assert.IsTrue(minesPointsValidator.Validate(correctSettings));
            Assert.IsFalse(minesPointsValidator.Validate(incorrectSettings));
        }
    }
}
