using escapemines.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace escapemines.Tests
{
    [TestClass]
    public class CoordinateTests
    {
        [TestMethod]
        public void ParsesCommaSeparatedValuesToCoordinate()
        {
            var correctCoordinate = new Coordinate("2, 3");

            Assert.AreEqual(new Coordinate(2, 3), correctCoordinate);
            Assert.ThrowsException<IncorrectCoordinateFormatException>(() => new Coordinate("test"));
        }

        [TestMethod]
        public void CoordinateEqualsOtherCoordinateWhenXAndYAreTheSame()
        {
            var firstCoordinate = new Coordinate(1, 3);
            var secondCoordinate = new Coordinate(1, 3);

            // I need to test only this method since == operator override and both Equals overrides use this method underneath
            Assert.IsTrue(Coordinate.Equals(firstCoordinate, secondCoordinate));
        }

        [TestMethod]
        public void CoordinateDoesNotEqualOtherCoordinateWhenXOrYAreDifferent()
        {
            var firstCoordinate = new Coordinate(1, 3);
            var secondCoordinate = new Coordinate(2, 3);
            var thirdCoordinate = new Coordinate(1, 4);

            // I need to test only this method since != operator override uses this method underneath
            Assert.IsTrue(Coordinate.DoesNotEqual(firstCoordinate, secondCoordinate));
            Assert.IsTrue(Coordinate.DoesNotEqual(firstCoordinate, thirdCoordinate));
        }
    }
}
