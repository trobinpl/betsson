using escapemines.Game;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace escapemines.Game
{
    public static class GameSettingsReader
    {
        public static GameSettings LoadSettings(string[] settingsTxt)
        {
            if(settingsTxt.Length < 5)
            {
                return null;
            }

            var boardSize = ReadValues(settingsTxt[0]);
            var mines = ReadMines(settingsTxt[1]);
            var exitPoint = ReadValues(settingsTxt[2]).AsCoordinate();
            var startingPosition = ReadStartingPosition(settingsTxt[3]);

            List<List<GameAction>> actionsLists = new List<List<GameAction>>();

            for (int i = 4; i < settingsTxt.Length; i++)
            {
                actionsLists.Add(ReadActions(settingsTxt[i]));
            }

            return new GameSettings(boardSize.A, boardSize.B, mines, exitPoint, startingPosition.StartingPoint, startingPosition.StartingDirection, actionsLists);
        }

        private static (int A, int B) ReadValues(string valuesLine)
        {
            var values = valuesLine.Split(' ');
            return (int.Parse(values[0]), int.Parse(values[1]));
        }

        private static Coordinate AsCoordinate(this (int, int) tulpe)
        {
            return new Coordinate(tulpe.Item1, tulpe.Item2);
        }

        private static HashSet<Coordinate> ReadMines(string minesLine)
        {
            var values = minesLine.Split(' ');
            return new HashSet<Coordinate>(values.Select(value => new Coordinate(value)));
        }

        private static (Coordinate StartingPoint, Direction StartingDirection) ReadStartingPosition(string startingPositionLine)
        {
            var values = startingPositionLine.Split(' ');
            Direction startingDirection;
            Enum.TryParse(values[2], out startingDirection);
            return (ReadValues(startingPositionLine).AsCoordinate(), startingDirection);
        }

        private static List<GameAction> ReadActions(string actionsLine)
        {
            var actions = new List<GameAction>();

            var actionsChars = actionsLine.Split(' ');
            foreach (var actionChar in actionsChars)
            {
                switch (actionChar)
                {
                    case "L":
                        actions.Add(GameAction.RotateLeft);
                        break;
                    case "R":
                        actions.Add(GameAction.RotateRight);
                        break;
                    case "M":
                        actions.Add(GameAction.Move);
                        break;
                }
            }

            return actions;
        }
    }
}
