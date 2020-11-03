using escapemines.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace escapemines.Tests
{
    [TestClass]
    public class MinefieldTests
    {
        [TestMethod]
        public void GeneratesSuccessOutcomeWhenTurtleEscapes()
        {
            var settingsLines = new string[]
            {
                "5 4",
                "1,2 2,2",
                "2 4",
                "2 1 N",
                "M M R M M R M M L M"
            };

            var settings = GameSettingsReader.LoadSettings(settingsLines);
            var board = new Board(settings.BoardWidth, settings.BoardHeight, settings.Mines, settings.ExitPoint);
            var turtle = new Turtle(settings.StartingPoint, settings.StartingDirection);

            var minefield = new Minefield(board, turtle);

            Assert.AreEqual(GameOutcome.Success, minefield.TryEscape(settings.ActionsLists[0]));
        }

        [TestMethod]
        public void GeneratesMineHitOutcomeWhenTurtleHitsMine()
        {
            var settingsLines = new string[]
            {
                "5 4",
                "1,2 2,2",
                "2 4",
                "2 1 N",
                "R M"
            };

            var settings = GameSettingsReader.LoadSettings(settingsLines);
            var board = new Board(settings.BoardWidth, settings.BoardHeight, settings.Mines, settings.ExitPoint);
            var turtle = new Turtle(settings.StartingPoint, settings.StartingDirection);

            var minefield = new Minefield(board, turtle);

            Assert.AreEqual(GameOutcome.MineHit, minefield.TryEscape(settings.ActionsLists[0]));
        }

        [TestMethod]
        public void GeneratesMineHitStillInDangerOutcomeWhenTurtleRemainsInTheMinefield()
        {
            var settingsLines = new string[]
            {
                "5 4",
                "1,2 2,2",
                "2 4",
                "2 1 N",
                "M M"
            };

            var settings = GameSettingsReader.LoadSettings(settingsLines);
            var board = new Board(settings.BoardWidth, settings.BoardHeight, settings.Mines, settings.ExitPoint);
            var turtle = new Turtle(settings.StartingPoint, settings.StartingDirection);

            var minefield = new Minefield(board, turtle);

            Assert.AreEqual(GameOutcome.StillInDanger, minefield.TryEscape(settings.ActionsLists[0]));
        }
    }
}
