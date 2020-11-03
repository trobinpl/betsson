using System;
using System.Collections.Generic;
using System.Text;

namespace escapemines.Game
{
    public struct Coordinate : IEquatable<Coordinate>
    {
        public Coordinate(string commaSeparatedValue)
        {
            var values = commaSeparatedValue.Split(',');

            if(values.Length != 2)
            {
                throw new IncorrectCoordinateFormatException("Incorrect coordinate string format. Please make sure you're passing comma-separated int values");
            }

            X = int.Parse(values[0]);
            Y = int.Parse(values[1]);
        }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }

        public static bool operator ==(Coordinate a, Coordinate b) => Equals(a, b);
        public static bool operator !=(Coordinate a, Coordinate b) => DoesNotEqual(a, b);

        public override bool Equals(object obj)
        {
            return obj is Coordinate coordinate && Equals(coordinate);
        }

        public bool Equals(Coordinate other)
        {
            return Equals(this, other);
        }

        public static bool Equals(Coordinate a, Coordinate b)
        {
            return a.X == b.X && a.Y == b.Y;
        }

        public static bool DoesNotEqual(Coordinate a, Coordinate b)
        {
            return a.X != b.X || a.Y != b.Y;
        }

        public override int GetHashCode()
        {
            return $"{X},{Y}".GetHashCode();
        }
    }
}
