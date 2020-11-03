using System;
using System.Collections.Generic;
using System.Text;

namespace escapemines.Game.Settings.Validation
{
    public interface IGameSettingsValidator
    {
        bool Validate(GameSettings settings);
    }
}
