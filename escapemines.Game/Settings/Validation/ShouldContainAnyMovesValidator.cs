using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace escapemines.Game.Settings.Validation
{
    public class ShouldContainAnyMovesValidator : IGameSettingsValidator
    {
        public bool Validate(GameSettings settings)
        {
            if (settings.ActionsLists.Any())
            {
                var valid = true;

                foreach(var actionList in settings.ActionsLists)
                {
                    valid &= actionList.Any();
                }

                return valid;
            }

            return false;
        }
    }
}
