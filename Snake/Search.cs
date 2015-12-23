using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Search
    {
        private bool[,] Marks;

        public List<Direction> FindPathToCell(SnakeBody snakeBody, Point dest)
        {
            var head = snakeBody.Head();
            Marks = new bool[Game.WIDTH, Game.HEIGHT];

            var nodeQueue = new Queue<SearchState>();
            nodeQueue.Enqueue(new SearchState(head));

            while (nodeQueue.Count > 0)
            {
                var newNode = nodeQueue.Dequeue();

                if (Marks[newNode.Head.X, newNode.Head.Y])
                    continue;

                foreach(var dir in Game.Directions)
                {
                    var newPoint = newNode.Head.AdjacentPoint(dir);
                    if (newPoint == dest) {
                        var route = newNode.TraceRoute();
                        route.Add(dir);
                        return route;
                    }

                    if(Is)
                }


            }
        }
    }
}
