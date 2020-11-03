using System;
using System.Collections.Generic;
using System.Text;

namespace escapemines.Game
{
    public class Turtle
    {
        private int _angle;

        public Turtle(Coordinate startingPosition, Direction startingDirection)
        {
            if(startingDirection == Direction.Unknown)
            {
                throw new ArgumentException("Starting direction can not be set as unknown");
            }

            Position = startingPosition;
            _angle = DirectionToAngle(startingDirection);
        }

        public Coordinate Position { get; private set; }
        public Direction Direction => AngleToDirection(_angle);

        public void Move(Func<Move, bool> movePossible)
        {
            if (movePossible(new Move(Position, Direction)))
            {
                switch (Direction)
                {
                    case Direction.N:
                        Position = new Coordinate(Position.X - 1, Position.Y);
                        break;
                    case Direction.E:
                        Position = new Coordinate(Position.X, Position.Y + 1);
                        break;
                    case Direction.S:
                        Position = new Coordinate(Position.X + 1, Position.Y);
                        break;
                    case Direction.W:
                        Position = new Coordinate(Position.X, Position.Y - 1);
                        break;
                }
            }
        }

        public void Rotate(GameAction action)
        {
            switch (action)
            {
                case GameAction.RotateLeft:
                    RotateLeft();
                    break;
                case GameAction.RotateRight:
                    RotateRight();
                    break;
            }
        }

        private void RotateLeft()
        {
            _angle = (_angle - 1) % 4;
        }

        private void RotateRight()
        {
            _angle = (_angle + 1) % 4;
        }

        private int DirectionToAngle(Direction direction)
        {
            switch (direction)
            {
                case Direction.N:
                    return 0;
                case Direction.E:
                    return 1;
                case Direction.S:
                    return 2;
                case Direction.W:
                    return 3;
            }

            throw new IncorrectDirectionException($"Value of {nameof(direction)} is neither N, W, S or E");
        }

        private Direction AngleToDirection(int angle)
        {
            switch (angle)
            {
                case 0:
                    return Direction.N;
                case 1:
                    return Direction.E;
                case 2:
                    return Direction.S;
                case 3:
                    return Direction.W;
            }

            throw new IncorrectAngleException($"Value of {nameof(angle)} is outside range of [0,3]");
        }
    }
}
