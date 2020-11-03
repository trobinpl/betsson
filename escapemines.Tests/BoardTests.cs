using escapemines.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace escapemines.Tests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void ChecksIfPointIsInsideBoard()
        {
            var board = new Board(100, 100, new HashSet<Coordinate>(), new Coordinate(0, 0));

            var firstPointInside = new Coordinate(1, 2);
            var secondPointInside = new Coordinate(99, 99);
            var firstPointOutside = new Coordinate(100, 100);
            var secondPointOutside = new Coordinate(-1, 1);

            Assert.IsTrue(board.IsInside(firstPointInside));
            Assert.IsTrue(board.IsInside(secondPointInside));
            Assert.IsFalse(board.IsInside(firstPointOutside));
            Assert.IsFalse(board.IsInside(secondPointOutside));
        }
        [TestMethod]
        public void MovePossibleWhenWithinBoardLimits()
        {
            var board = new Board(5, 4, new HashSet<Coordinate>(), new Coordinate(0, 0));

            var moveNorth = new Move(new Coordinate(2, 0), Direction.N);
            var moveEast = new Move(new Coordinate(2, 0), Direction.E);
            var moveSouth = new Move(new Coordinate(2, 3), Direction.S);
            var moveWest = new Move(new Coordinate(2, 3), Direction.W);

            Assert.IsTrue(board.MovePossible(moveNorth));
            Assert.IsTrue(board.MovePossible(moveEast));
            Assert.IsTrue(board.MovePossible(moveSouth));
            Assert.IsTrue(board.MovePossible(moveWest));
        }

        [TestMethod]
        public void MoveImpossibleWhenOutsideBoardLimits()
        {
            var board = new Board(5, 4, new HashSet<Coordinate>(), new Coordinate(0, 0));

            var moveNorth = new Move(new Coordinate(0, 0), Direction.N);
            var moveEast = new Move(new Coordinate(3, 4), Direction.E);
            var moveSouth = new Move(new Coordinate(3, 1), Direction.S);
            var moveWest = new Move(new Coordinate(2, 0), Direction.W);

            Assert.IsFalse(board.MovePossible(moveNorth));
            Assert.IsFalse(board.MovePossible(moveEast));
            Assert.IsFalse(board.MovePossible(moveSouth));
            Assert.IsFalse(board.MovePossible(moveWest));
        }

        [TestMethod]
        public void MoveImpossibleWhenDirectionIsUnknown()
        {
            var board = new Board(5, 4, new HashSet<Coordinate>(), new Coordinate(0, 0));

            var move = new Move(new Coordinate(0, 0), Direction.Unknown);

            Assert.IsFalse(board.MovePossible(move));
        }
    }
}
