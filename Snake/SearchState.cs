using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class SearchState
    {
        public Point Head;
        public Direction Dir;
        public SearchState Parent;

        public SearchState(Point head)
        {
            Head = head;
        }

        public SearchState(Point head, Direction dir)
        {
            Head = head;
            Dir = dir;
        }

        public List<Direction> TraceRoute()
        {
            if(Parent == null)
            {
                return new List<Direction>();
            } else
            {
                var parentRoute = Parent.TraceRoute();
                parentRoute.Add(dir);
                return parentRoute;
            }
        }
    }
}
