using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace escapemines.Game
{
    public class Minefield
    {
        private readonly Turtle _turtle;
        private readonly Board _board;

        public Minefield(Board board, Turtle turtle)
        {
            _board = board;
            _turtle = turtle;
        }

        public GameOutcome TryEscape(List<GameAction> actions)
        {
            foreach (var action in actions)
            {
                ActUpon(action);

                if (_board.Mines.Contains(_turtle.Position))
                {
                    return GameOutcome.MineHit;
                }

                if (_turtle.Position == _board.ExitPoint)
                {
                    return GameOutcome.Success;
                }
            }

            return GameOutcome.StillInDanger;
        }

        private void ActUpon(GameAction action)
        {
            if(action == GameAction.Move)
            {
                _turtle.Move(_board.MovePossible);
            }
            else
            {
                _turtle.Rotate(action);
            }
        }
    }
}
