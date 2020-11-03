using System;
using System.Collections.Generic;
using System.Text;

namespace escapemines.Game.Settings.Validation
{
    // just to show the idea of how I imagine validation would look like
    internal static class GameSettingsValidationDefaults
    {
        public static List<IGameSettingsValidator> DefaultValidators = new List<IGameSettingsValidator>()
        {
            new ShouldContainAnyMovesValidator(),
            new MineCantLayAtExitPointValidator(),
            new PointCantBeOutsideOfBoardValidator(settings => settings.StartingPoint),
            new PointCantBeOutsideOfBoardValidator(settings => settings.ExitPoint),
            new PointsCantBeOutsideOfBoardValidator(settings => settings.Mines)
        };
    }
}
