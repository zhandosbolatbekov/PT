using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAKE.Models
{
    public class Food : Drawer
    {
        public Food()
        {
            sign = '@';
            color = ConsoleColor.White;
            NewRandomPosition();
            while (anyCollision(body[0].x, body[0].y))
                NewRandomPosition();
        }

        public bool anyCollision(int x, int y) 
        {
            foreach (Point p in Game.snake.body)
                if (p.x == x && p.y == y)
                    return true;

            //foreach (Point p in Game.wall.body)
            //    if (p.x == x && p.y == y)
            //        return true;

            return false;
        }

        public void NewRandomPosition()
        {
            int x = new Random().Next() % 80;
            int y = new Random().Next() % 25;
            if (body.Count == 0)
                body.Add(new Point(x, y));
            else
            {
                body[0].x = x;
                body[0].y = y;
            }
        }
    }
}
