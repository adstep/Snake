using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public struct Point
    {
        public sbyte X;
        public sbyte Y;

        public Point(sbyte x, sbyte y)
        {
            X = x;
            Y = y;
        }

        public Point AdjacentPoint(Direction d)
        {
            switch(d)
            {
                case Direction.UP:
                    return new Point(X, (sbyte)(Y - 1));
                case Direction.DOWN:
                    return new Point(X, (sbyte)(Y + 1));
                case Direction.LEFT:
                    return new Point((sbyte)(X - 1), Y);
                case Direction.RIGHT:
                    return new Point((sbyte)(X + 1), Y);
                default:
                    throw new Exception("Unknown direction: AdjacentPoint");
            }
        }

        public bool IsInbounds()
        {
            return (0 <= X && X < Game.WIDTH) && (0 <= Y && Y < Game.HEIGHT);
        }

        #region Equality

        public override bool Equals(object obj)
        {
            if (!(obj is Point))
                return false;

            Point p = (Point)obj;
            return ((p.X == X) && (p.Y == Y));
        }

        public static bool operator ==(Point p1, Point p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(Point p1, Point p2)
        {
            return !p1.Equals(p2);
        }

        #endregion

        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
}
