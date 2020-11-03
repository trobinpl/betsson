using escapemines.Game.Settings.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace escapemines.Game
{
    public class GameSettings
    {
        public GameSettings(int boardWidth, int boardHeight, IEnumerable<Coordinate> mines, Coordinate exitPoint, Coordinate startingPoint, Direction startingDirection, List<List<GameAction>> actionsLists)
            : this(boardWidth, boardHeight, mines, exitPoint, startingPoint, startingDirection, actionsLists, GameSettingsValidationDefaults.DefaultValidators)
        {
            
        }

        public GameSettings(int boardWidth, int boardHeight, IEnumerable<Coordinate> mines, Coordinate exitPoint, Coordinate startingPoint, Direction startingDirection, List<List<GameAction>> actionsLists, List<IGameSettingsValidator> validators)
        {
            BoardWidth = boardWidth;
            BoardHeight = boardHeight;
            Mines = mines;
            ExitPoint = exitPoint;
            StartingPoint = startingPoint;
            StartingDirection = startingDirection;
            ActionsLists = actionsLists;
            _validators = validators;
        }

        public int BoardWidth { get; private set; }
        public int BoardHeight { get; private set; }
        public IEnumerable<Coordinate> Mines { get; private set; }
        public Coordinate ExitPoint { get; private set; }
        public Coordinate StartingPoint { get; private set; }
        public Direction StartingDirection { get; private set; }
        public List<List<GameAction>> ActionsLists { get; private set; }

        private List<IGameSettingsValidator> _validators = new List<IGameSettingsValidator>();

        public bool Valid()
        {
            if (_validators.Any())
            {
                var settingsValid = true;

                foreach(var validator in _validators)
                {
                    settingsValid = settingsValid && validator.Validate(this);
                }

                return settingsValid;
            }
            else
            {
                return true;
            }
        }
    }
}
