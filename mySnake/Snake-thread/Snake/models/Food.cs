using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.models
{
    [Serializable]
    class Food : Drawer
    {
        public Food()
        {
            sign = '@';
            color = ConsoleColor.Yellow;
        }
        public void setNewPos()
        {
            int x = new Random().Next() % 80;
            int y = new Random().Next() % 25;
            while (badPosition(x, y))
            {
                x = new Random().Next() % 80;
                y = new Random().Next() % 25;
            }
            Console.ForegroundColor = color;
            if (body.Count == 0)
            {
                body.Add(new Point(x, y));
                Console.SetCursorPosition(x, y);
                Console.Write(sign);
            }
            else
            {
                Console.SetCursorPosition(body[0].x, body[0].y);
                Console.Write(" ");
                body[0].x = x;
                body[0].y = y;
                Console.SetCursorPosition(body[0].x, body[0].y);
                Console.Write(sign);
            }
        }
        public bool badPosition(int x, int y)
        {
            foreach (Point p in Game.snake.body)
                if (p.x == x && p.y == y)
                    return true;
            foreach (Point p in Game.wall.body)
                if (p.x == x && p.y == y)
                    return true;
            return false;
        }
    }
}
