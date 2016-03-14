using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAKE.Models
{
    public class Snake : Drawer
    {
        public Snake()
        {
            sign = 'o';
            color = ConsoleColor.Green;
            body.Add(new Point(10, 10));
        }
        public void move(int dx, int dy)
        {
            Point tail = new Point(body[body.Count - 1].x, body[body.Count - 1].y);
            for (int i = body.Count - 1; i > 0; --i)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }
            body[0].x = (body[0].x + dx + 80) % 80;
            body[0].y = (body[0].y + dy + 25) % 25;

            if (body[0].x == Game.food.body[0].x &&
                body[0].y == Game.food.body[0].y)
            {
                body.Add(tail);
                Game.food.NewRandomPosition();
            }
        }
        public bool anyCollision()
        {
            for (int i = 1; i < body.Count; ++i)
                if (body[i].x == body[0].x && body[i].y == body[0].y)
                    return true;

            foreach (Point p in Game.wall.body)
                if (p.x == body[0].x && p.y == body[0].y)
                    return true;

            return false;
        }
    }
}
