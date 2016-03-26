using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.models
{
    [Serializable]
    class Snake : Drawer 
    {
        public Snake() 
        {
            sign = 'O';
            color = ConsoleColor.Green;
        }
        public override void Draw()
        {
            for (int i = 0; i < body.Count; i++)
            {
                if (i == 0)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else
                    Console.ForegroundColor = color;
                Console.SetCursorPosition(body[i].x, body[i].y);
                Console.Write(sign);
            }
        }
        public void move(int dx, int dy)
        {
            Point tail = new Point(body[body.Count - 1].x, body[body.Count - 1].y);
            Console.ForegroundColor = Game.snake.color;
            Console.SetCursorPosition(tail.x, tail.y);
            Console.Write(' ');
            for (int i = body.Count - 1; i > 0; --i)
            {
                body[i].x = body[i-1].x;
                body[i].y = body[i-1].y;
            }
            body[0].x = (body[0].x + dx + 80) % 80;
            body[0].y = (body[0].y + dy + 25) % 25;

            if (body[0].x == Game.food.body[0].x && body[0].y == Game.food.body[0].y)
            {
                Game.PTS += 1;
                body.Add(tail);
                Game.food.setNewPos();
            }
            for (int i = 1; i < body.Count; ++i)
                if (body[i].x == body[0].x && body[i].y == body[0].y)
                    Game.GameOver = true;
            foreach (Point p in Game.wall.body)
                if (p.x == body[0].x && p.y == body[0].y)
                    Game.GameOver = true;
        }
    }
}
