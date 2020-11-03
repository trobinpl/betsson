using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace escapemines.Game.Settings.Validation
{
    public class PointCantBeOutsideOfBoardValidator : IGameSettingsValidator
    {
        private Func<GameSettings, Coordinate> _pointSelector;

        public PointCantBeOutsideOfBoardValidator(Func<GameSettings, Coordinate> pointSelector)
        {
            _pointSelector = pointSelector;
        }

        public static bool Validate(Coordinate point, GameSettings settings)
        {
            var board = new Board(settings.BoardWidth, settings.BoardHeight, new HashSet<Coordinate>(), new Coordinate(0, 0));
            return board.IsInside(point);
        }

        public bool Validate(GameSettings settings)
        {
            return Validate(_pointSelector(settings), settings);
        }
    }
}
