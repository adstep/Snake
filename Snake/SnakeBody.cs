using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public enum Direction: sbyte
    {
        LEFT = 0,
        RIGHT = 1,
        DOWN = 2,
        UP = 3,
        UNKNOWN = 8
    }

    public class SnakeBody
    {
        public List<Point> Body;
        public HashSet<Point> BodySet;
        public Direction Direction;

        public SnakeBody(Point head)
        {
            Body = new List<Point>();
            Body.Add(head);
            BodySet.Add(head);

            Direction = Direction.RIGHT;
        }

        public Point Head()
        {
            return Body[0];
        }

        public Point Tail()
        {
            return Body.Last();
        }

        public SnakeBody Fork()
        {
            var newSnake = new SnakeBody(new Point(0, 0));

            newSnake.Body = Utils.CopyList(Body);
            newSnake.Direction = Direction;

            return newSnake;
        }

        public void Advance(Direction command)
        {
            if (Utils.IsOpposite(command, Direction))
                command = Direction;

            var newHead = Head().AdjacentPoint(command);
            Body.Insert(0, newHead);
            BodySet.Add(newHead);
            Direction = command;
        }

        public void Move(Direction command)
        {
            if (Utils.IsOpposite(command, Direction))
                command = Direction;

            Advance(command);
            BodySet.Remove(Tail());
            Body.RemoveAt(Body.Count());
        }

        public bool BodyHit()
        {
            var head = Head();

            for(int i = 1; i < Body.Count(); i++)
            {
                if (head == Body[i])
                    return true;
            }

            return false;
        }

        public bool WallHit()
        {
            var head = Head();
            return (0 <= head.X && head.X < Game.WIDTH) && (0 <= head.Y && head.Y < Game.HEIGHT);
        }
    }
}
