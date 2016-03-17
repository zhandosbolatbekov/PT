using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.models
{
    [Serializable]
    class Point
    {
        public int x, y;
        public Point() { }
        public Point(int X, int Y) { x = X; y = Y; }
    }
}
