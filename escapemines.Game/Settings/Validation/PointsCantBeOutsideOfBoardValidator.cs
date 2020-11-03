using System;
using System.Collections.Generic;
using System.Text;

namespace escapemines.Game.Settings.Validation
{
    public class PointsCantBeOutsideOfBoardValidator : IGameSettingsValidator
    {
        private Func<GameSettings, IEnumerable<Coordinate>> _pointsSelector;
        
        public PointsCantBeOutsideOfBoardValidator(Func<GameSettings, IEnumerable<Coordinate>> pointsSelector)
        {
            _pointsSelector = pointsSelector;
        }

        public bool Validate(GameSettings settings)
        {
            var points = _pointsSelector(settings);

            var valid = true;

            foreach(var point in points)
            {
                valid &= PointCantBeOutsideOfBoardValidator.Validate(point, settings);
            }

            return valid;
        }
    }
}
