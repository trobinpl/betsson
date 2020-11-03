using escapemines.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace escapemines.Tests
{
    [TestClass]
    public class GameSettingsReaderTests
    {
        [TestMethod]
        public void ReadsSettings()
        {
            var settingsLines = new string[]
            {
                "5 4",
                "1,1 1,3 3,3",
                "4 2",
                "0 1 N",
                "R M L M M R M M M"
            };

            var settings = GameSettingsReader.LoadSettings(settingsLines);

            Assert.AreEqual(5, settings.BoardWidth);
            Assert.AreEqual(4, settings.BoardHeight);

            Assert.IsTrue(settings.Mines.Contains(new Coordinate(1, 1)));
            Assert.IsTrue(settings.Mines.Contains(new Coordinate(1, 3)));
            Assert.IsTrue(settings.Mines.Contains(new Coordinate(3, 3)));

            Assert.AreEqual(new Coordinate(4, 2), settings.ExitPoint);

            Assert.AreEqual(new Coordinate(0, 1), settings.StartingPoint);
            Assert.AreEqual(Direction.N, settings.StartingDirection);
        }

        [TestMethod]
        public void ValidatesSettings()
        {
            var correctSettingsLines = new string[]
            {
                "5 4",
                "1,1 1,3 3,3",
                "2 4",
                "0 1 N",
                "R M L M M R M M M"
            };

            var missingMovesSettingsLines = new string[]
            {
                "5 4",
                "1,1 1,3 3,3",
                "4 2",
                "0 1 N",
                ""
            };

            var startingPointOutsideBoardSettingsLines = new string[]
            {
                "5 4",
                "1,1 1,3 3,3",
                "4 2",
                "0 6 N",
                ""
            };

            var correctSettings = GameSettingsReader.LoadSettings(correctSettingsLines);
            var missingMovesSettings = GameSettingsReader.LoadSettings(missingMovesSettingsLines);
            var startingPointOutsideBoardSettings = GameSettingsReader.LoadSettings(startingPointOutsideBoardSettingsLines);

            Assert.IsTrue(correctSettings.Valid());
            Assert.IsFalse(missingMovesSettings.Valid());
            Assert.IsFalse(startingPointOutsideBoardSettings.Valid());
        }

        [TestMethod]
        public void ReturnsNullWhenIncompleteSettingsProvided()
        {
            var completeSettingsLines = new string[]
            {
                "5 4",
                "1,1 1,3 3,3",
                "2 4",
                "0 1 N",
                "R M L M M R M M M"
            };

            var incompleteSettingsLines = new string[]
            {
                "5 4",
                "1,1 1,3 3,3",
                "2 4",
                "0 1 N"
            };

            var completeSettings = GameSettingsReader.LoadSettings(completeSettingsLines);
            var incompleteSettings = GameSettingsReader.LoadSettings(incompleteSettingsLines);

            Assert.IsNotNull(completeSettings);
            Assert.IsNull(incompleteSettings);
        }
    }
}
