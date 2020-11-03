using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace escapemines.Game.Settings.Validation
{
    public class MineCantLayAtExitPointValidator : IGameSettingsValidator
    {
        public bool Validate(GameSettings settings)
        {
            return !settings.Mines.Any(minePosition => settings.ExitPoint == minePosition);
        }
    }
}
