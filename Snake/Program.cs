using Snake;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();

            Point p1 = new Point(1, 1);
            Point p2 = new Point(1, 1);

            Console.WriteLine(p1 == p2);
            Console.WriteLine(System.Runtime.InteropServices.Marshal.SizeOf(typeof(Point)));

            List<Point> points = new List<Point>();

            for(int i =0; i < 100; i++)
            {
                points.Add(new Point((byte)i, (byte)i));
            }
            
            watch.Reset();
            watch.Start();

            var copy = Utils.CopyList(points);

            watch.Stop();

            Console.WriteLine(watch.ElapsedTicks);

            watch.Reset();
            watch.Start();

            var copy2 = Utils.Clone(points);

            watch.Stop();

            Console.WriteLine(watch.ElapsedTicks);

            for (int i = 0; i < 100; i++)
            {
                Debug.Assert(copy[i] == points[i]);
            }

            Console.WriteLine("gotem");
            Console.ReadLine();
        }
    }
}
