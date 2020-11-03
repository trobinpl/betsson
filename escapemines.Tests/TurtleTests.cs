using escapemines.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace escapemines.Tests
{
    [TestClass]
    public class TurtleTests
    {
        private Func<Move, bool> movePossible = (Move move) => true;
        private Func<Move, bool> moveImpossible = (Move move) => false;

        [TestMethod]
        public void InitializesPosition()
        {
            var turtle = new Turtle(new Coordinate(3, 2), Direction.S);

            Assert.AreEqual(new Coordinate(3, 2), turtle.Position);
            Assert.AreEqual(Direction.S, turtle.Direction);
        }

        [TestMethod]
        public void MovesWhenMovePossible()
        {
            var turtle = new Turtle(new Coordinate(3, 2), Direction.S);

            turtle.Move(movePossible);
            turtle.Move(movePossible);

            Assert.AreEqual(new Coordinate(5, 2), turtle.Position);
        }

        [TestMethod]
        public void DoesntMoveWhenMoveImpossible()
        {
            var turtle = new Turtle(new Coordinate(3, 2), Direction.S);

            turtle.Move(moveImpossible);

            Assert.AreEqual(new Coordinate(3, 2), turtle.Position);
        }

        [TestMethod]
        public void Rotates()
        {
            var firstTurtle = new Turtle(new Coordinate(3, 2), Direction.S);
            var secondTurtle = new Turtle(new Coordinate(3, 2), Direction.S);

            firstTurtle.Rotate(GameAction.RotateLeft);
            firstTurtle.Rotate(GameAction.RotateLeft);

            secondTurtle.Rotate(GameAction.RotateRight);

            Assert.AreEqual(Direction.N, firstTurtle.Direction);
            Assert.AreEqual(Direction.W, secondTurtle.Direction);
        }
    }
}
