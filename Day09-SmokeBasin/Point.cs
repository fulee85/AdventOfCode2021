using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day09_SmokeBasin
{
    public class Point
    {
        private List<Point> higherNeighbour;

        public Point(int height)
        {
            Height = height;
        }

        public int Height { get; }

        public bool IsLowPoint()
        {
            throw new NotImplementedException();
        }

        public void AddHigherNeighbour(Point point)
        {

        }
    }
}
