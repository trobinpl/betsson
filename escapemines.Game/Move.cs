using System;
using System.Collections.Generic;
using System.Text;

namespace escapemines.Game
{
    public struct Move
    {
        public Move(Coordinate currentPosition, Direction currentDirection)
        {
            CurrentPosition = currentPosition;
            CurrentDirection = currentDirection;
        }

        public Coordinate CurrentPosition { get; private set; }
        public Direction CurrentDirection { get; private set; }
    }
}
