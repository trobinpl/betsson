using System.Collections.Generic;

namespace escapemines.Game
{
    public class Board
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public IEnumerable<Coordinate> Mines { get; private set; }
        public Coordinate ExitPoint { get; private set; }

        public Board(int width, int height, IEnumerable<Coordinate> mines, Coordinate exitPoint)
        {
            Width = width;
            Height = height;
            Mines = mines;
            ExitPoint = exitPoint;
        }

        public bool MovePossible(Move move)
        {
            switch (move.CurrentDirection)
            {
                case Direction.N:
                    return IsInside(new Coordinate(move.CurrentPosition.X - 1, move.CurrentPosition.Y));
                case Direction.S:
                    return IsInside(new Coordinate(move.CurrentPosition.X + 1, move.CurrentPosition.Y));
                case Direction.W:
                    return IsInside(new Coordinate(move.CurrentPosition.X, move.CurrentPosition.Y - 1));
                case Direction.E:
                    return IsInside(new Coordinate(move.CurrentPosition.X, move.CurrentPosition.Y + 1));
            }

            return false;
        }

        public bool IsInside(Coordinate point)
        {
            return point.X >= 0 && point.X < Height && point.Y >= 0 && point.Y < Width;
        }
    }
}
